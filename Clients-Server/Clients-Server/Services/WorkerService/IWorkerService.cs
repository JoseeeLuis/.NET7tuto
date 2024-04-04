using Clients_Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Clients_Server.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<WorkerDTO>> GetAllWorkers();
        Task<WorkerDTO> GetSingleWorker(int WorkerId);
        Task<Response> DeleteWorker(int WorkerId);
        Task<Response> CreateWorker(PostWorkerDTO postWorkerDTO,
                                               IAddressRepository addressRepository,
                                               IWorkerDetailsRepository workerDetailsRepository,
                                               IWorkerRepository workerRepository);
        //Task<List<Worker>> GetByDepartament(string DepartamentTypeCode);
        //Task<List<Worker>> GetBySeniority(string SeniorityTypeCode);
        //Task<List<Worker>> GetByProject(int ProjectId);
    }
}
