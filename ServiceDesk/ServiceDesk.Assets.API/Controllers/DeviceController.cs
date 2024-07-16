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
    public class DeviceController : ControllerBase
    {
        private readonly IBaseService<Device, DeviceDto> _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IBaseService<Device, DeviceDto> deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<DeviceDto>>>> GetDevices()
        {
            var devices = await _deviceService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<DeviceDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(devices)
                .WithMessage("Devices retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<DeviceDto>>> GetDeviceById(Guid id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<DeviceDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Device not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<DeviceDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(device)
                .WithMessage("Device retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<DeviceDto>>> AddDevice(CreateDeviceDto deviceDto)
        {
            await _deviceService.AddAsync(_mapper.Map<DeviceDto>(deviceDto));
            var result = new CrudOperationResultBuilder<DeviceDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<DeviceDto>(deviceDto))
                .WithMessage("Device added successfully")
                .Build();

            return CreatedAtAction(nameof(GetDeviceById), new { id = _mapper.Map<DeviceDto>(deviceDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<DeviceDto>>> UpdateDevice(Guid id, CreateDeviceDto deviceDto)
        {
            await _deviceService.UpdateAsync(id, _mapper.Map<DeviceDto>(deviceDto));
            var updateResult = new CrudOperationResultBuilder<DeviceDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<DeviceDto>(deviceDto))
                .WithMessage("Device updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<DeviceDto>>> DeleteDevice(Guid id)
        {
            await _deviceService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<DeviceDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Device deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
