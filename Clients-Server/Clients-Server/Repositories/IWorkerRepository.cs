namespace Clients_Server.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> AddWorkerAsync(Worker worker);
    }
}
