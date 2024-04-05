using Clients_Server.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Clients_Server.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<WorkerDTO>> GetAllWorkers();
        Task<WorkerDTO> GetSingleWorker(int WorkerId);
        Task<Boolean> DeleteWorker(int WorkerId);
        Task<Boolean> CreateWorker(PostWorkerDTO postWorkerDTO);
        //Task<List<Worker>> GetByDepartament(string DepartamentTypeCode);
        //Task<List<Worker>> GetBySeniority(string SeniorityTypeCode);
        //Task<List<Worker>> GetByProject(int ProjectId);
    }
}
