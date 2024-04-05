using Clients_Server.Data;

namespace Clients_Server.Repositories
{
    public class WorkerDetailsRepository : IWorkerDetailsRepository
    {
        private readonly DataContext _context;

        public WorkerDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<WorkerDetails> AddWorkerDetailsAsync(WorkerDetails workerDetails)
        {
            _context.WorkersDetails.Add(workerDetails);
            await _context.SaveChangesAsync();
            return workerDetails;
        }
    }
}
