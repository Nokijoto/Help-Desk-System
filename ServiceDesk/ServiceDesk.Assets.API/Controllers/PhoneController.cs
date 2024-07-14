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
    public class PhoneController : ControllerBase
    {
        private readonly IBaseService<Phone, PhoneDto> _phoneService;
        private readonly IMapper _mapper;

        public PhoneController(IBaseService<Phone, PhoneDto> phoneService, IMapper mapper)
        {
            _phoneService = phoneService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<PhoneDto>>>> GetPhones()
        {
            var phones = await _phoneService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<PhoneDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(phones)
                .WithMessage("Phones retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<PhoneDto>>> GetPhoneById(Guid id)
        {
            var phone = await _phoneService.GetByIdAsync(id);
            if (phone == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<PhoneDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Phone not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<PhoneDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(phone)
                .WithMessage("Phone retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<PhoneDto>>> AddPhone(CreatePhoneDto phoneDto)
        {
            await _phoneService.AddAsync(_mapper.Map<PhoneDto>(phoneDto));
            var result = new CrudOperationResultBuilder<PhoneDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PhoneDto>(phoneDto))
                .WithMessage("Phone added successfully")
                .Build();

            return CreatedAtAction(nameof(GetPhoneById), new { id = _mapper.Map<PhoneDto>(phoneDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<PhoneDto>>> UpdatePhone(Guid id, CreatePhoneDto phoneDto)
        {
            await _phoneService.UpdateAsync(id, _mapper.Map<PhoneDto>(phoneDto));
            var updateResult = new CrudOperationResultBuilder<PhoneDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PhoneDto>(phoneDto))
                .WithMessage("Phone updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<PhoneDto>>> DeletePhone(Guid id)
        {
            await _phoneService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<PhoneDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Phone deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
