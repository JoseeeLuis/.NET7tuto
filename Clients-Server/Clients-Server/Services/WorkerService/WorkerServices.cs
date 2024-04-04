using Clients_Server.Data;
using Clients_Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Services.WorkerService
{
    public class WorkerServices : IWorkerService
    {
        private readonly DataContext _context;

        public WorkerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<WorkerDTO>> GetAllWorkers()
        {
            var workers =await  _context.Workers
                .Include(w => w.Address)
                .Include(w => w.Projects)
                .Include(w=>w.WorkerDetails)
                .Include(w=>w.WorkerDetails.DepartamentType)
                .Include(w=>w.WorkerDetails.SeniorityType)
                .Where(w => !w.IsDelete) 
                .ToListAsync();

            var formatWorkers=  workers.Select(w=>w.ToDto()).ToList();
            return formatWorkers;
        }

        public async Task<WorkerDTO> GetSingleWorker(int WorkerId)
        {
            var worker = await _context.Workers
                .Include(w => w.WorkerDetails)
                .Include(w => w.Address)
                .Include(w => w.Projects)
                .Include(w => w.WorkerDetails)
                .Include(w => w.WorkerDetails.DepartamentType)
                .Include(w => w.WorkerDetails.SeniorityType)
                .FirstOrDefaultAsync(w => w.WorkerId == WorkerId);
            
            if (worker == null)
            {
                return null;
            }
            var workerFormat = worker.ToDto();

            return workerFormat;
        }


        public async Task<Response> DeleteWorker(int WorkerId)
        {
            var response = new Response();
            try
            {
                var worker = await _context.Workers.FirstOrDefaultAsync(w => w.WorkerId == WorkerId);
                if (worker != null)
                {
                    worker.IsDelete = true;
                    await _context.SaveChangesAsync();
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

                response.StatusCode = 500;
                response.Message = "An error occurred while deleting the worker: " + ex.Message;

            }
            return response;
        }

        public async Task<Response> CreateWorker(PostWorkerDTO postWorkerDTO,
                                                            IAddressRepository addressRepository,
                                                            IWorkerDetailsRepository workerDetailsRepository,
                                                            IWorkerRepository workerRepository)
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

                await addressRepository.AddAddressAsync(address);

                var workerDetails = new WorkerDetails
                {
                    SeniorityTypeCode = postWorkerDTO.SeniorityTypeCode,
                    JoiningDate = postWorkerDTO.JoiningDate,
                    DepartamentTypeCode = postWorkerDTO.DepartamentTypeCode,
                };

                await workerDetailsRepository.AddWorkerDetailsAsync(workerDetails);

                var worker = new Worker
                {
                    WorkerName = postWorkerDTO.WorkerName,
                    AddressId = address.AddressId,
                    WorkerDetailsId = workerDetails.WorkerDetailsId,
                };

                await workerRepository.AddWorkerAsync(worker);

                response.StatusCode = 200;
                response.Message = "Worker created successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
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
