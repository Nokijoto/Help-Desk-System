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
    public class CableController : ControllerBase
    {
        private readonly IBaseService<Cable, CableDto> _CableService;
        private readonly IMapper _mapper;

        public CableController(IBaseService<Cable, CableDto> CableService, IMapper mapper)
        {
            _CableService = CableService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<CableDto>>>> GetCables()
        {
            var Cables = await _CableService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<CableDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(Cables)
                .WithMessage("Cables retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<CableDto>>> GetCableById(Guid id)
        {
            var Cable = await _CableService.GetByIdAsync(id);
            if (Cable == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<CableDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Cable not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<CableDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(Cable)
                .WithMessage("Cable retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<CableDto>>> AddCable(CreateCableDto CableDto)
        {

            await _CableService.AddAsync(_mapper.Map<CableDto>(CableDto));
            var result = new CrudOperationResultBuilder<CableDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<CableDto>(CableDto))
                .WithMessage("Cable added successfully")
                .Build();

            return CreatedAtAction(nameof(GetCableById), new { id = _mapper.Map<CableDto>(CableDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<CableDto>>> UpdateCable(Guid id, CreateCableDto CableDto)
        {
            //if (id != _mapper.Map<CableDto>(CableDto).Guid)
            //{
            //    var result = new CrudOperationResultBuilder<CableDto>()
            //        .WithStatus(CrudOperationResultStatus.Failure)
            //        .WithMessage("Cable ID mismatch")
            //        .Build();
            //    return BadRequest(result);
            //}

            await _CableService.UpdateAsync(_mapper.Map<CableDto>(CableDto));
            var updateResult = new CrudOperationResultBuilder<CableDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<CableDto>(CableDto))
                .WithMessage("Cable updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<CableDto>>> DeleteCable(Guid id)
        {
            await _CableService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<CableDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Cable deleted successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<CrudOperationResult<List<CableDto>>>> FilterCables([FromBody] Dictionary<string, object> searchParams)
        {
           
            var cables = await _CableService.FilterAsync(searchParams);
            var result = new CrudOperationResultBuilder<List<CableDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(cables)
                .WithMessage("Cables retrieved successfully")
                .Build();

            return Ok(result);
        }
    }
}
