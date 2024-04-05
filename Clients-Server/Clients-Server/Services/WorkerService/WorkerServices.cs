using Clients_Server.DTOS;
using Clients_Server.Repositories;

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

            var formatWorkers = workers.Select(WorkerDTO.FromWorker)
                                       .ToList();
            return formatWorkers;
        }

        public async Task<WorkerDTO> GetSingleWorker(int WorkerId)
        {
            var worker = await _workerRepository.GetSingleWorkerAsync(WorkerId);
            
            if (worker == null)
            {
                return null;
            }
            var workerFormat = WorkerDTO.FromWorker(worker);

            return workerFormat;
        }


        public async Task<Boolean> DeleteWorker(int WorkerId)
        {
            var Sucessfully = false;
            try
            {
                var response = await _workerRepository.DeleteWorkerAsync(WorkerId);
                if (response == false)
                {
                    Sucessfully = false;
                }
                else
                {
                    Sucessfully = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while Delete the worker: ", ex.Message, ex.HResult);
                Sucessfully = false;
            }

            
            return Sucessfully;
        }

        public async Task<Boolean> CreateWorker(PostWorkerDTO postWorkerDTO)
        {
            var Succesfully = true;
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
                await _workerRepository.AddWorkerAsync(worker);
                Log.Information("worker created with id", worker.WorkerId);
                Succesfully= true;
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while creating the worker: ", ex.Message, ex.HResult);
                Succesfully = false;
            }

            return Succesfully;
        }


        //public async Task<List<Worker>> GetBySeniority(string SeniorityTypeCode)
        //{

        //}

        //public async Task<List<Worker>> GetByProject(int ProjectId)
        //{

        //}

    }
}
