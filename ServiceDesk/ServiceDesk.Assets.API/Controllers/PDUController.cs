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
    public class PDUController : ControllerBase
    {
        private readonly IBaseService<PDU, PDUDto> _pduService;
        private readonly IMapper _mapper;

        public PDUController(IBaseService<PDU, PDUDto> pduService, IMapper mapper)
        {
            _pduService = pduService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<PDUDto>>>> GetPDUs()
        {
            var pdus = await _pduService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<PDUDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(pdus)
                .WithMessage("PDUs retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<PDUDto>>> GetPDUById(Guid id)
        {
            var pdu = await _pduService.GetByIdAsync(id);
            if (pdu == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<PDUDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("PDU not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<PDUDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(pdu)
                .WithMessage("PDU retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<PDUDto>>> AddPDU(CreatePDUDto pduDto)
        {
            await _pduService.AddAsync(_mapper.Map<PDUDto>(pduDto));
            var result = new CrudOperationResultBuilder<PDUDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PDUDto>(pduDto))
                .WithMessage("PDU added successfully")
                .Build();

            return CreatedAtAction(nameof(GetPDUById), new { id = _mapper.Map<PDUDto>(pduDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<PDUDto>>> UpdatePDU(Guid id, CreatePDUDto pduDto)
        {
            await _pduService.UpdateAsync(id, _mapper.Map<PDUDto>(pduDto));
            var updateResult = new CrudOperationResultBuilder<PDUDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PDUDto>(pduDto))
                .WithMessage("PDU updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<PDUDto>>> DeletePDU(Guid id)
        {
            await _pduService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<PDUDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("PDU deleted successfully")
                .Build();

            return Ok(result);
        }
    }

}
