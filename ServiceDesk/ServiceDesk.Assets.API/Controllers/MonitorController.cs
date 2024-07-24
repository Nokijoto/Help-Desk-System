using AutoMapper;
using CrudBase;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Assets.API.Builders;
using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.CrossCutting.Dtos.CreateDto;
using ServiceDesk.Assets.CrossCutting.Dtos;

namespace ServiceDesk.Assets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        private readonly IBaseService<Storage.Entities.Monitor, MonitorDto> _monitorService;
        private readonly IMapper _mapper;

        public MonitorController(IBaseService<Storage.Entities.Monitor, MonitorDto> monitorService, IMapper mapper)
        {
            _monitorService = monitorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<MonitorDto>>>> GetMonitors()
        {
            var monitors = await _monitorService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<MonitorDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(monitors)
                .WithMessage("Monitors retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<MonitorDto>>> GetMonitorById(Guid id)
        {
            var monitor = await _monitorService.GetByIdAsync(id);
            if (monitor == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<MonitorDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Monitor not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<MonitorDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(monitor)
                .WithMessage("Monitor retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<MonitorDto>>> AddMonitor(CreateMonitorDto monitorDto)
        {
            await _monitorService.AddAsync(_mapper.Map<MonitorDto>(monitorDto));
            var result = new CrudOperationResultBuilder<MonitorDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<MonitorDto>(monitorDto))
                .WithMessage("Monitor added successfully")
                .Build();

            return CreatedAtAction(nameof(GetMonitorById), new { id = _mapper.Map<MonitorDto>(monitorDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<MonitorDto>>> UpdateMonitor(Guid id, CreateMonitorDto monitorDto)
        {
            await _monitorService.UpdateAsync(id, _mapper.Map<MonitorDto>(monitorDto));
            var updateResult = new CrudOperationResultBuilder<MonitorDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<MonitorDto>(monitorDto))
                .WithMessage("Monitor updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<MonitorDto>>> DeleteMonitor(Guid id)
        {
            await _monitorService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<MonitorDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Monitor deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
