using Microsoft.AspNetCore.Mvc;

namespace Clients_Server.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<WorkerDTO>> GetAllWorkers();
        Task<WorkerDTO> GetSingleWorker(int WorkerId);
        //Task<List<Worker>> DeleteWorker(int WorkerId);

        Task<List<WorkerDTO>> CreateWorker(PostWorkerDTO postWorkerDTO);
        //Task<List<Worker>> GetByDepartament(string DepartamentTypeCode);
        //Task<List<Worker>> GetBySeniority(string SeniorityTypeCode);
        //Task<List<Worker>> GetByProject(int ProjectId);
    }
}
