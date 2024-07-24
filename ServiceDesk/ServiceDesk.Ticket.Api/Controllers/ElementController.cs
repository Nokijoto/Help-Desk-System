using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElement([FromRoute] Guid id)
        {
            var elements = await _elementService.GetAssetsForTicket(id);
            return Ok(elements);
        }
        [HttpPost("{id}/dodaj")]
        public async Task<IActionResult> AddElements([FromRoute] Guid id, [FromBody] ElementDtoName assetId) 
        {
            await _elementService.AddElements(id, assetId.Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement([FromRoute] Guid id)
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
