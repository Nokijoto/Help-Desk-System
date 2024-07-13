using AutoMapper;
using CrudBase;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Assets.API.Builders;
using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Assets.CrossCutting.Dtos.CreateDto;
using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IBaseService<Computer,ComputerDto> _computerService;
        private readonly IMapper _mapper;

        public ComputerController(IBaseService<Computer,ComputerDto> computerService,IMapper mapper)
        {
            _computerService = computerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<ComputerDto>>>> GetComputers()
        {
            var computers = await _computerService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<ComputerDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(computers)
                .WithMessage("Computers retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<ComputerDto>>> GetComputerById(Guid id)
        {
            var computer = await _computerService.GetByIdAsync(id);
            if (computer == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<ComputerDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Computer not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<ComputerDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(computer)
                .WithMessage("Computer retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<ComputerDto>>> AddComputer(CreateComputerDto computerDto)
        {
            
            await _computerService.AddAsync(_mapper.Map<ComputerDto>(computerDto));
            var result = new CrudOperationResultBuilder<ComputerDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<ComputerDto>(computerDto))
                .WithMessage("Computer added successfully")
                .Build();

            return CreatedAtAction(nameof(GetComputerById), new { id = _mapper.Map<ComputerDto>(computerDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<ComputerDto>>> UpdateComputer(Guid id, CreateComputerDto computerDto)
        {
            if (id != _mapper.Map<ComputerDto>(computerDto).Guid)
            {
                var result = new CrudOperationResultBuilder<ComputerDto>()
                    .WithStatus(CrudOperationResultStatus.Failure)
                    .WithMessage("Computer ID mismatch")
                    .Build();
                return BadRequest(result);
            }

            await _computerService.UpdateAsync(_mapper.Map<ComputerDto>(computerDto));
            var updateResult = new CrudOperationResultBuilder<ComputerDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<ComputerDto>(computerDto))
                .WithMessage("Computer updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<ComputerDto>>> DeleteComputer(Guid id)
        {
            await _computerService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<ComputerDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Computer deleted successfully")
                .Build();

            return Ok(result);
        }
        [HttpPost("filter")]
        public async Task<ActionResult<CrudOperationResult<List<ComputerDto>>>> FilterComputers([FromBody] Dictionary<string, object> searchParams)
        {
           
            var computers = await _computerService.FilterAsync(searchParams);
            var result = new CrudOperationResultBuilder<List<ComputerDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(computers)
                .WithMessage("Computers retrieved successfully")
                .Build();

            return Ok(result);
        }

    }
}
