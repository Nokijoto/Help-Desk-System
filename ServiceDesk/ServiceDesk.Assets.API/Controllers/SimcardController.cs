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
    public class SimcardController : ControllerBase
    {
        private readonly IBaseService<Simcard, SimcardDto> _simcardService;
        private readonly IMapper _mapper;

        public SimcardController(IBaseService<Simcard, SimcardDto> simcardService, IMapper mapper)
        {
            _simcardService = simcardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<SimcardDto>>>> GetSimcards()
        {
            var simcards = await _simcardService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<SimcardDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(simcards)
                .WithMessage("Simcards retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<SimcardDto>>> GetSimcardById(Guid id)
        {
            var simcard = await _simcardService.GetByIdAsync(id);
            if (simcard == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<SimcardDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Simcard not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<SimcardDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(simcard)
                .WithMessage("Simcard retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<SimcardDto>>> AddSimcard(CreateSimcardDto simcardDto)
        {
            await _simcardService.AddAsync(_mapper.Map<SimcardDto>(simcardDto));
            var result = new CrudOperationResultBuilder<SimcardDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<SimcardDto>(simcardDto))
                .WithMessage("Simcard added successfully")
                .Build();

            return CreatedAtAction(nameof(GetSimcardById), new { id = _mapper.Map<SimcardDto>(simcardDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<SimcardDto>>> UpdateSimcard(Guid id, CreateSimcardDto simcardDto)
        {
            await _simcardService.UpdateAsync(id, _mapper.Map<SimcardDto>(simcardDto));
            var updateResult = new CrudOperationResultBuilder<SimcardDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<SimcardDto>(simcardDto))
                .WithMessage("Simcard updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<SimcardDto>>> DeleteSimcard(Guid id)
        {
            await _simcardService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<SimcardDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Simcard deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
