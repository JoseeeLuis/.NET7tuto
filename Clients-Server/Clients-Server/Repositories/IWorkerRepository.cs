using Clients_Server.Models;

namespace Clients_Server.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> AddWorkerAsync(Worker worker);
        Task<List<Worker>> GetAllWorkersAsync();
        Task<int> DeleteWorkerAsync(Worker worker);
        Task<Worker> GetSingleWorkerAsync(int WorkerId);
    }
}
