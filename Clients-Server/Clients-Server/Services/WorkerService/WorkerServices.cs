using Clients_Server.Data;
using Clients_Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clients_Server.Services.WorkerService
{
    public class WorkerServices : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IWorkerDetailsRepository _workerDetailsRepository;
        public WorkerServices(IWorkerRepository workerRepository,
                              IAddressRepository addressRepository,
                              IWorkerDetailsRepository workerDetailsRepository)
        {
            _workerRepository = workerRepository;
            _addressRepository = addressRepository;
            _workerDetailsRepository = workerDetailsRepository;
        }

        public async Task<List<WorkerDTO>> GetAllWorkers()
        {

            var workers =await _workerRepository.GetAllWorkersAsync();

            var formatWorkers = workers.Select(w => w.ToDto())
                                       .ToList();
            return formatWorkers;
        }

        public async Task<WorkerDTO> GetSingleWorker(int WorkerId)
        {
            var worker = await _workerRepository.GetSingleWorkerAsync(WorkerId);
            
            if (worker == null)
            {
                return /*NotFoundObjectResult*/null;
            }
            var workerFormat = worker.ToDto();

            return workerFormat;
        }


        public async Task<Response> DeleteWorker(int WorkerId)
        {
            var response = new Response();
            try
            {
                var worker =await _workerRepository.GetSingleWorkerAsync(WorkerId);
                if (worker != null)
                {
                    await _workerRepository.DeleteWorkerAsync(worker);
                    response.StatusCode = 200;
                    response.Message = "Worker deleted successfully";
                    
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Worker NotFound";
                }
    
            }

            catch (Exception ex) {

                response.StatusCode = ex.HResult;
                response.Message = "An error occurred while deleting the worker: " + ex.Message;
            }
            return response;
        }

        public async Task<Response> CreateWorker(PostWorkerDTO postWorkerDTO)
        {
            var response = new Response();

            try
            {
                var address = new Address
                {
                    Street = postWorkerDTO.Street,
                    StreetNumber = postWorkerDTO.StreetNumber,
                    State = postWorkerDTO.State,
                    PostalCode = postWorkerDTO.PostalCode,
                };

                await _addressRepository.AddAddressAsync(address);

                var workerDetails = new WorkerDetails
                {
                    SeniorityTypeCode = postWorkerDTO.SeniorityTypeCode,
                    JoiningDate = postWorkerDTO.JoiningDate,
                    DepartamentTypeCode = postWorkerDTO.DepartamentTypeCode,
                };

                await _workerDetailsRepository.AddWorkerDetailsAsync(workerDetails);

                var worker = new Worker
                {
                    WorkerName = postWorkerDTO.WorkerName,
                    AddressId = address.AddressId,
                    WorkerDetailsId = workerDetails.WorkerDetailsId,
                };
                Log.Information("worker created with id", worker.WorkerId);
                await _workerRepository.AddWorkerAsync(worker);

                response.StatusCode = 200;
                response.Message = "Worker created successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = ex.HResult;
                Log.Error("An error occurred while creating the worker: ", ex.Message, ex.HResult);
                response.Message = "An error occurred while creating the worker: " + ex.Message;
            }

            return response;
        }


        //public async Task<List<Worker>> GetBySeniority(string SeniorityTypeCode)
        //{

        //}

        //public async Task<List<Worker>> GetByProject(int ProjectId)
        //{

        //}

    }
}
