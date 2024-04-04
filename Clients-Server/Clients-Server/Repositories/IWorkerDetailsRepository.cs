namespace Clients_Server.Repositories
{
    public interface IWorkerDetailsRepository
    {
        Task<WorkerDetails> AddWorkerDetailsAsync(WorkerDetails workerDetails);
    }
}
