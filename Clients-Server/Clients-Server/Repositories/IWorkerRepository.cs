namespace Clients_Server.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> AddWorkerAsync(Worker worker);
        Task<List<Worker>> GetAllWorkersAsync();
        Task<Boolean> DeleteWorkerAsync(int workerId);
        Task<Worker> GetSingleWorkerAsync(int WorkerId);
    }
}
