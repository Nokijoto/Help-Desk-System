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
    public class PrinterController : ControllerBase
    {
        private readonly IBaseService<Printer, PrinterDto> _printerService;
        private readonly IMapper _mapper;

        public PrinterController(IBaseService<Printer, PrinterDto> printerService, IMapper mapper)
        {
            _printerService = printerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CrudOperationResult<List<PrinterDto>>>> GetPrinters()
        {
            var printers = await _printerService.GetAllAsync();
            var result = new CrudOperationResultBuilder<List<PrinterDto>>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(printers)
                .WithMessage("Printers retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrudOperationResult<PrinterDto>>> GetPrinterById(Guid id)
        {
            var printer = await _printerService.GetByIdAsync(id);
            if (printer == null)
            {
                var notFoundResult = new CrudOperationResultBuilder<PrinterDto>()
                    .WithStatus(CrudOperationResultStatus.RecordNotFound)
                    .WithMessage("Printer not found")
                    .Build();
                return NotFound(notFoundResult);
            }

            var result = new CrudOperationResultBuilder<PrinterDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(printer)
                .WithMessage("Printer retrieved successfully")
                .Build();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CrudOperationResult<PrinterDto>>> AddPrinter(CreatePrinterDto printerDto)
        {
            await _printerService.AddAsync(_mapper.Map<PrinterDto>(printerDto));
            var result = new CrudOperationResultBuilder<PrinterDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PrinterDto>(printerDto))
                .WithMessage("Printer added successfully")
                .Build();

            return CreatedAtAction(nameof(GetPrinterById), new { id = _mapper.Map<PrinterDto>(printerDto).Guid }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CrudOperationResult<PrinterDto>>> UpdatePrinter(Guid id, CreatePrinterDto printerDto)
        {
            await _printerService.UpdateAsync(id, _mapper.Map<PrinterDto>(printerDto));
            var updateResult = new CrudOperationResultBuilder<PrinterDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithResult(_mapper.Map<PrinterDto>(printerDto))
                .WithMessage("Printer updated successfully")
                .Build();

            return Ok(updateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CrudOperationResult<PrinterDto>>> DeletePrinter(Guid id)
        {
            await _printerService.DeleteAsync(id);
            var result = new CrudOperationResultBuilder<PrinterDto>()
                .WithStatus(CrudOperationResultStatus.Success)
                .WithMessage("Printer deleted successfully")
                .Build();

            return Ok(result);
        }
    }


}
