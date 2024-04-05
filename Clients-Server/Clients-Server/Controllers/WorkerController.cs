using Clients_Server.DTOS;
using Clients_Server.Services.WorkerService;
using Microsoft.AspNetCore.Mvc;

namespace Clients_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerServices;
        public WorkerController(IWorkerService workerServices)
        {
            _workerServices = workerServices;
        }
        [HttpGet]
        public async Task<List<WorkerDTO>> GetAllWorkers()
        {
            return await _workerServices.GetAllWorkers();
        }

        [HttpGet("{WorkerId}")]
        public async Task<ActionResult<Worker>> GetSingleWorker(int WorkerId)
        {
            var worker = await _workerServices.GetSingleWorker(WorkerId);
            if (worker is null)
            {
                return NotFound("This worker doesn't exist");
            }
            return Ok(worker);
        }


        [HttpDelete("WorkerId")]
        public async Task<IActionResult> DeleteHero(int WorkerId)

        {

            var result = await _workerServices.DeleteWorker(WorkerId);

            if (result == true)
            {
                return Ok("Worker delete successfully");
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker(PostWorkerDTO postWorkerDTO)
        {
            var result = await _workerServices.CreateWorker(postWorkerDTO);

            if (result == true)
            {
                return Ok("Successfully created worker");
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }


    }
}
