using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;

namespace Web_Application_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly QueueService _queueService;

        public QueueController(QueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueRecord>>> Get()
        {
            var records = await _queueService.GetRecordsForDisplayAsync();
            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QueueRecord newRecord)
        {
            if (newRecord == null)
            {
                return BadRequest("Record data is missing.");
            }

            try
            {
                await _queueService.AddRecordAsync(newRecord);
                return CreatedAtAction(nameof(Get), new { id = newRecord.Id }, newRecord);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}