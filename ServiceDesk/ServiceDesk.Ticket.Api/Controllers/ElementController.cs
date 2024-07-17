using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Ticket.Api.Interfaces;

namespace ServiceDesk.Ticket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementController : ControllerBase
    {
        private readonly IElementService _elementService;
        public ElementController(IElementService elementService)
        {
            _elementService=elementService;
        }
        [HttpGet]
        public async Task<IActionResult> GetElement(Guid id)
        {
            var elements = await _elementService.GetAssetsForTicket(id);
            return Ok(elements);
        }
        [HttpPost]
        public async Task<IActionResult> AddElements(Guid id, string assetId) //do poprwy
        {
            await _elementService.AddElements(id, assetId);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement(Guid id)
        {
            try
            {
                await _elementService.DeleteElement(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
