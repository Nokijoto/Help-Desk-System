using AutoMapper;
using CrudBase;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Assets.API.Builders;
using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.CrossCutting.Dtos.CreateDto;
using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RackController : ControllerBase
    {
        private readonly IBaseService<Rack, RackDto> _rackService;
        private readonly IMapper _mapper;

        public RackController(IBaseService<Rack, RackDto> rackService, IMapper mapper)
        {
            _rackService = rackService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<RackDto>>>> GetRacks()
        {
            var racks = await _rackService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<RackDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(racks)
                .WithMessage("Racks retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<RackDto>>> GetRackById(Guid id)
        {
            var rack = await _rackService.GetByIdAsync(id);
            if (rack == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<RackDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Rack not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<RackDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(rack)
                .WithMessage("Rack retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<RackDto>>> AddRack(CreateRackDto rackDto)
        {
            await _rackService.AddAsync(_mapper.Map<RackDto>(rackDto));
            var result = new CrudOperationResultBuilder<RackDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<RackDto>(rackDto))
                .WithMessage("Rack added successfully")
                .Build();

            return CreatedAtAction(nameof(GetRackById), new { id = _mapper.Map<RackDto>(rackDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<RackDto>>> UpdateRack(Guid id, CreateRackDto rackDto)
        {
            await _rackService.UpdateAsync(id, _mapper.Map<RackDto>(rackDto));
            var updateResult = new CrudOperationResultBuilder<RackDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<RackDto>(rackDto))
                .WithMessage("Rack updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<RackDto>>> DeleteRack(Guid id)
        {
            await _rackService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<RackDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Rack deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
