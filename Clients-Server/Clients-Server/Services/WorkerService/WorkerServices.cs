using Clients_Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Services.WorkerService
{
    public class WorkerServices : IWorkerService
    {
        private readonly DataContext _context;

        public WorkerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<WorkerDTO>> GetAllWorkers()
        {
            var workers =await  _context.Workers
                .Include(w => w.Address)
                .Include(w => w.Projects)
                .Include(w=>w.WorkerDetails)
                .Include(w=>w.WorkerDetails.DepartamentType)
                .Include(w=>w.WorkerDetails.SeniorityType)
                .ToListAsync();

            var formatWorkers=  workers.Select(w=>w.ToDto()).ToList();
            return formatWorkers;
        }

        public async Task<WorkerDTO> GetSingleWorker(int WorkerId)
        {
            var worker = await _context.Workers
                .Include(w => w.WorkerDetails)
                .Include(w => w.Address)
                .FirstOrDefaultAsync(w => w.WorkerId == WorkerId);
            
            if (worker == null)
            {
                return null;
            }
            var workerFormat = worker.ToDto();

            return workerFormat;
        }


        //public async Task<List<Worker>> DeleteWorker(int WorkerId)
        //{
        //    var worker = await _context.Workers
        //        .Include(w => w.WorkerDetails)
        //        .Include(w => w.Address)
        //        .FirstOrDefaultAsync(w => w.WorkerId == WorkerId);
        //    if (worker is null)
        //        return null;
        //    _context.Workers.Remove(worker);
        //    await _context.SaveChangesAsync();
        //    var workers = await _context.Workers.ToListAsync();
        //    return workers;
        //}
        public async Task<List<WorkerDTO>> CreateWorker(PostWorkerDTO postWorkerDTO)
        {
            var address = new Address
            {
                Street = postWorkerDTO.Street,
                StreetNumber = postWorkerDTO.StreetNumber,
                State = postWorkerDTO.State,
                PostalCode = postWorkerDTO.PostalCode,
            };
           await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            
            var workerDetails = new WorkerDetails
            {
                SeniorityTypeCode = postWorkerDTO.SeniorityTypeCode,
                JoiningDate = postWorkerDTO.JoiningDate,
                DepartamentTypeCode = postWorkerDTO.DepartamentTypeCode,
            };
             await _context.WorkersDetails.AddAsync(workerDetails);
            await _context.SaveChangesAsync();
            var worker = new Worker
            {
                WorkerName = postWorkerDTO.WorkerName,
                AddressId = address.AddressId,
                WorkerDetailsId =workerDetails.WorkerDetailsId,

            };
            await _context.Workers.AddAsync(worker);
    
            await _context.SaveChangesAsync();
            var workers =  await GetAllWorkers();
            if (workers == null)
            {
                return null;
            }



            return workers;
        }

        //public async Task<List<Worker>> GetBySeniority(string SeniorityTypeCode)
        //{

        //}

        //public async Task<List<Worker>> GetByProject(int ProjectId)
        //{

        //}

    }
}
