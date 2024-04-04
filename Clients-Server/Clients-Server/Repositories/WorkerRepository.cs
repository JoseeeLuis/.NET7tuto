using Clients_Server.Data;
using Clients_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;

        public WorkerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            var workers = await _context.Workers
                .Include(w => w.Address)
                .Include(w => w.Projects)
                .Include(w => w.WorkerDetails)
                .Include(w => w.WorkerDetails.DepartamentType)
                .Include(w => w.WorkerDetails.SeniorityType)
                .Where(w => !w.IsDelete)
                .ToListAsync();
            return workers;
        }
        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return worker;
        }
        public async Task<Worker> GetSingleWorkerAsync(int WorkerId)
        {
            var worker = await _context.Workers
                .Include(w => w.WorkerDetails)
                .Include(w => w.Address)
                .Include(w => w.Projects)
                .Include(w => w.WorkerDetails)
                .Include(w => w.WorkerDetails.DepartamentType)
                .Include(w => w.WorkerDetails.SeniorityType)
                .FirstOrDefaultAsync(w => w.WorkerId == WorkerId);

            return worker;
        }
        public async Task<int> DeleteWorkerAsync(Worker worker){
            worker.IsDelete = true;
            await _context.SaveChangesAsync();
            return worker.WorkerId;
        }

    }
}
    