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
    public class SoftwareController : ControllerBase
    {
        private readonly IBaseService<Software, SoftwareDto> _softwareService;
        private readonly IMapper _mapper;

        public SoftwareController(IBaseService<Software, SoftwareDto> softwareService, IMapper mapper)
        {
            _softwareService = softwareService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<SoftwareDto>>>> GetSoftwares()
        {
            var softwares = await _softwareService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<SoftwareDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(softwares)
                .WithMessage("Softwares retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<SoftwareDto>>> GetSoftwareById(Guid id)
        {
            var software = await _softwareService.GetByIdAsync(id);
            if (software == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<SoftwareDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Software not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<SoftwareDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(software)
                .WithMessage("Software retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<SoftwareDto>>> AddSoftware(CreateSoftwareDto softwareDto)
        {
            await _softwareService.AddAsync(_mapper.Map<SoftwareDto>(softwareDto));
            var result = new CrudOperationResultBuilder<SoftwareDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<SoftwareDto>(softwareDto))
                .WithMessage("Software added successfully")
                .Build();

            return CreatedAtAction(nameof(GetSoftwareById), new { id = _mapper.Map<SoftwareDto>(softwareDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<SoftwareDto>>> UpdateSoftware(Guid id, CreateSoftwareDto softwareDto)
        {
            await _softwareService.UpdateAsync(id, _mapper.Map<SoftwareDto>(softwareDto));
            var updateResult = new CrudOperationResultBuilder<SoftwareDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<SoftwareDto>(softwareDto))
                .WithMessage("Software updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<SoftwareDto>>> DeleteSoftware(Guid id)
        {
            await _softwareService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<SoftwareDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Software deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
