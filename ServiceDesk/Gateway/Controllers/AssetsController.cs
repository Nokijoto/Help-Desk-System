using CrudBase;
using Gateway.Clients;
using Gateway.Enums;
using Gateway.Factories;
using Gateway.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Gateway.Storage.Dtos.AssetsCreateDto;

namespace Gateway.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IApiClientFactory _ClientFactory;
        private readonly String serviceUrl;
        public AssetsController(IApiClientFactory ClientFactory, IConfiguration configuration) 
        {
            _ClientFactory = ClientFactory;
            serviceUrl = configuration.GetSection("ApiSettings:AssetsUrl").Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Computers()
        {
            var Client = _ClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
              ViewBag.DtoType = "ComputerDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
         
        }

        [HttpGet]
        public async Task<IActionResult> Cables()
        {

            var Client = _ClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
            ViewBag.DtoType = "CableDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);

        }

        [HttpGet]
        public async Task<IActionResult> Phone()
        {

            var Client = _ClientFactory.CreateClient<PhoneDto>($"{serviceUrl}Phone");
            ViewBag.DtoType = "PhoneDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);

        }
        [HttpGet]
        public async Task<IActionResult> Device()
        {
            var Client = _ClientFactory.CreateClient<DeviceDto>($"{serviceUrl}Device");
            ViewBag.DtoType = "DeviceDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }

        [HttpGet]
        public async Task<IActionResult> Rack()
        {
            var Client = _ClientFactory.CreateClient<RackDto>($"{serviceUrl}Rack");
            ViewBag.DtoType = "RackDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }


        [HttpGet]
        public async Task<IActionResult> PDU()
        {
            var Client = _ClientFactory.CreateClient<PDUDto>($"{serviceUrl}PDU");
            ViewBag.DtoType = "PDUDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }


        [HttpGet]
        public async Task<IActionResult> Printer()
        {
            var Client = _ClientFactory.CreateClient<PrinterDto>($"{serviceUrl}Printer");
            ViewBag.DtoType = "PrinterDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }


        [HttpGet]
        public async Task<IActionResult> Monitor()
        {
            var Client = _ClientFactory.CreateClient<MonitorDto>($"{serviceUrl}Monitor");
            ViewBag.DtoType = "MonitorDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }

        [HttpGet]
        public async Task<IActionResult> Simcard()
        {
            var Client = _ClientFactory.CreateClient<SimcardDto>($"{serviceUrl}Simcard");
            ViewBag.DtoType = "SimcardDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }

        [HttpGet]
        public async Task<IActionResult> Software()
        {
            var Client = _ClientFactory.CreateClient<SoftwareDto>($"{serviceUrl}Software");
            ViewBag.DtoType = "SoftwareDto";
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string type, Guid id)
        {
            
            var item = await GetDetailsAsync(type, id);
            if (item == null)
            {
                return NotFound();
            }
            return View("GenericDetails", item);
        }



        private async Task<dynamic> GetDetailsAsync(string type, Guid id)
        {
            switch (type.ToLower())
            {
                case "computer":
                    var computerClient = _ClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                    return await computerClient.GetByIdAsync(id);
                case "cable":
                    var cableClient = _ClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                    return await cableClient.GetByIdAsync(id);
                case "device":
                    var deviceClient = _ClientFactory.CreateClient<DeviceDto>($"{serviceUrl}Device");
                    return await deviceClient.GetByIdAsync(id);
                case "monitor":
                    var monitorClient = _ClientFactory.CreateClient<MonitorDto>($"{serviceUrl}Monitor");
                    return await monitorClient.GetByIdAsync(id);
                case "pdu":
                    var pduClient = _ClientFactory.CreateClient<PDUDto>($"{serviceUrl}PDU");
                    return await pduClient.GetByIdAsync(id);
                case "phone":
                    var phoneClient = _ClientFactory.CreateClient<PhoneDto>($"{serviceUrl}Phone");
                    return await phoneClient.GetByIdAsync(id);
                case "printer":
                    var printerClient = _ClientFactory.CreateClient<PrinterDto>($"{serviceUrl}Printer");
                    return await printerClient.GetByIdAsync(id);
                case "rack":
                    var rackClient = _ClientFactory.CreateClient<RackDto>($"{serviceUrl}Rack");
                    return await rackClient.GetByIdAsync(id);
                case "simcard":
                    var simcardClient = _ClientFactory.CreateClient<SimcardDto>($"{serviceUrl}Simcard");
                    return await simcardClient.GetByIdAsync(id);
                case "software":
                    var softwareClient = _ClientFactory.CreateClient<SoftwareDto>($"{serviceUrl}Software");
                    return await softwareClient.GetByIdAsync(id);
                default:
                    return null;
            }
        }

        [HttpGet("Create/{type}")]
        public IActionResult Create(string type)
        {
            dynamic model = GetModelByType(type);
            if (model == null)
            {
                return BadRequest("Invalid type");
            }

            ViewBag.DtoType = type;
            return View("GenericCreate", model);
        }

        [HttpPost("Create/{type}")]
        public async Task<IActionResult> Create(string type, [FromForm] Dictionary<string, string> formValues)
        {
            var model = GetModelByType(type);
            if (model == null)
            {
                return BadRequest("Invalid type");
            }

            MapFormValuesToModel(formValues, model);

            var result = await CreateItemAsync(type, model);
            if (!result)
            {
                return BadRequest();
            }
            return RedirectToAction("GenericView", new { type });
        }

        private dynamic GetModelByType(string type)
        {
            switch (type.ToLower())
            {
                case "computerdto":
                    return new CreateComputerDto();
                case "cabledto":
                    return new CreateCableDto();
                case "devicedto":
                    return new CreateDeviceDto();
                case "monitordto":
                    return new CreateMonitorDto();
                case "pdudto":
                    return new CreatePDUDto();
                case "phonedto":
                    return new CreatePhoneDto();
                case "printerdto":
                    return new CreatePrinterDto();
                case "rackdto":
                    return new CreateRackDto();
                case "simcarddto":
                    return new CreateSimcardDto();
                case "softwaredto":
                    return new CreateSoftwareDto();
                default:
                    return null;
            }
        }
        private async Task<bool> CreateItemAsync(string type, dynamic model)
        {
            try
            {
                switch (type.ToLower())
                {
                    case "computerdto":
                        var computerDto = new CreateComputerDto();
                        MapDynamicToDto(model, computerDto);
                        var computerClient = _ClientFactory.CreateClient<CreateComputerDto>($"{serviceUrl}Computer");
                        await computerClient.CreateAsync(computerDto);
                        break;

                    case "cabledto":
                        var cableDto = new CreateCableDto();
                        MapDynamicToDto(model, cableDto);
                        var cableClient = _ClientFactory.CreateClient<CreateCableDto>($"{serviceUrl}Cable");
                        await cableClient.CreateAsync(cableDto);
                        break;

                    case "devicedto":
                        var deviceDto = new CreateDeviceDto();
                        MapDynamicToDto(model, deviceDto);
                        var deviceClient = _ClientFactory.CreateClient<CreateDeviceDto>($"{serviceUrl}Device");
                        await deviceClient.CreateAsync(deviceDto);
                        break;

                    case "monitordto":
                        var monitorDto = new CreateMonitorDto();
                        MapDynamicToDto(model, monitorDto);
                        var monitorClient = _ClientFactory.CreateClient<CreateMonitorDto>($"{serviceUrl}Monitor");
                        await monitorClient.CreateAsync(monitorDto);
                        break;

                    case "pdudto":
                        var pduDto = new CreatePDUDto();
                        MapDynamicToDto(model, pduDto);
                        var pduClient = _ClientFactory.CreateClient<CreatePDUDto>($"{serviceUrl}PDU");
                        await pduClient.CreateAsync(pduDto);
                        break;

                    case "phonedto":
                        var phoneDto = new CreatePhoneDto();
                        MapDynamicToDto(model, phoneDto);
                        var phoneClient = _ClientFactory.CreateClient<CreatePhoneDto>($"{serviceUrl}Phone");
                        await phoneClient.CreateAsync(phoneDto);
                        break;

                    case "printerdto":
                        var printerDto = new CreatePrinterDto();
                        MapDynamicToDto(model, printerDto);
                        var printerClient = _ClientFactory.CreateClient<CreatePrinterDto>($"{serviceUrl}Printer");
                        await printerClient.CreateAsync(printerDto);
                        break;

                    case "rackdto":
                        var rackDto = new CreateRackDto();
                        MapDynamicToDto(model, rackDto);
                        var rackClient = _ClientFactory.CreateClient<CreateRackDto>($"{serviceUrl}Rack");
                        await rackClient.CreateAsync(rackDto);
                        break;

                    case "simcarddto":
                        var simcardDto = new CreateSimcardDto();
                        MapDynamicToDto(model, simcardDto);
                        var simcardClient = _ClientFactory.CreateClient<CreateSimcardDto>($"{serviceUrl}Simcard");
                        await simcardClient.CreateAsync(simcardDto);
                        break;

                    case "softwaredto":
                        var softwareDto = new CreateSoftwareDto();
                        MapDynamicToDto(model, softwareDto);
                        var softwareClient = _ClientFactory.CreateClient<CreateSoftwareDto>($"{serviceUrl}Software");
                        await softwareClient.CreateAsync(softwareDto);
                        break;

                    default:
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        private void MapFormValuesToModel(Dictionary<string, string> formValues, dynamic model)
        {
            foreach (var property in model.GetType().GetProperties())
            {
                if (formValues.ContainsKey(property.Name))
                {
                    var value = Convert.ChangeType(formValues[property.Name], property.PropertyType);
                    property.SetValue(model, value);
                }
            }
        }


        //private void MapDynamicToDto(dynamic source, object destination)
        //{
        //    foreach (var prop in destination.GetType().GetProperties())
        //    {
        //        var value = source.GetType().GetProperty(prop.Name)?.GetValue(source, null);
        //        if (value != null)
        //        {
        //            prop.SetValue(destination, value);
        //        }
        //    }
        //}
        private void MapDynamicToDto(dynamic source, object destination)
        {
            var sourceDict = (IDictionary<string, object>)source;

            foreach (var property in destination.GetType().GetProperties())
            {
                if (property.CanWrite && sourceDict.ContainsKey(property.Name))
                {
                    var value = sourceDict[property.Name];
                    if (value != null)
                    {
                        property.SetValue(destination, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string type, Guid id)
        {
            var item = await GetDetailsAsync(type, id);
            if (item == null)
            {
                return NotFound();
            }
            return View("GenericUpdate", item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string type, [FromForm] IDictionary<string, object> modelData)
        {
            if (modelData == null)
            {
                ModelState.AddModelError("", "Model data is null.");
                return View("GenericUpdate", modelData);
            }


            if (modelData.ContainsKey("Guid") && Guid.TryParse(modelData["Guid"]?.ToString(), out var guid))
            {
                dynamic model = new ExpandoObject();
                var modelDict = (IDictionary<string, object>)model;

                foreach (var key in modelData.Keys)
                {
                    modelDict[key] = modelData[key];
                }


                var result = await UpdateItemAsync(type, model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Update failed.");
            }
            else
            {
                ModelState.AddModelError("", "Model is missing the required 'Guid' property or it is invalid.");
            }

            return View("GenericUpdate", modelData);
        }




        private async Task<bool> UpdateItemAsync(string type, dynamic model)
        {
            try
            {
                switch (type.ToLower())
                {
                    case "computerdto":
                        var computerDto = new ComputerDto();
                        MapDynamicToDto(model, computerDto);
                        var computerClient = _ClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                        await computerClient.UpdateAsync((Guid)model.Guid, computerDto);
                        break;

                    case "cabledto":
                        var cableDto = new CableDto();
                        MapDynamicToDto(model, cableDto);
                        var cableClient = _ClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                        await cableClient.UpdateAsync((Guid)model.Guid, cableDto);
                        break;

                    case "devicedto":
                        var deviceDto = new DeviceDto();
                        MapDynamicToDto(model, deviceDto);
                        var deviceClient = _ClientFactory.CreateClient<DeviceDto>($"{serviceUrl}Device");
                        await deviceClient.UpdateAsync((Guid)model.Guid, deviceDto);
                        break;

                    case "monitordto":
                        var monitorDto = new MonitorDto();
                        MapDynamicToDto(model, monitorDto);
                        var monitorClient = _ClientFactory.CreateClient<MonitorDto>($"{serviceUrl}Monitor");
                        await monitorClient.UpdateAsync((Guid)model.Guid, monitorDto);
                        break;

                    case "pdudto":
                        var pduDto = new PDUDto();
                        MapDynamicToDto(model, pduDto);
                        var pduClient = _ClientFactory.CreateClient<PDUDto>($"{serviceUrl}PDU");
                        await pduClient.UpdateAsync((Guid)model.Guid, pduDto);
                        break;

                    case "phonedto":
                        var phoneDto = new PhoneDto();
                        MapDynamicToDto(model, phoneDto);
                        var phoneClient = _ClientFactory.CreateClient<PhoneDto>($"{serviceUrl}Phone");
                        await phoneClient.UpdateAsync((Guid)model.Guid, phoneDto);
                        break;

                    case "printerdto":
                        var printerDto = new PrinterDto();
                        MapDynamicToDto(model, printerDto);
                        var printerClient = _ClientFactory.CreateClient<PrinterDto>($"{serviceUrl}Printer");
                        await printerClient.UpdateAsync((Guid)model.Guid, printerDto);
                        break;

                    case "rackdto":
                        var rackDto = new RackDto();
                        MapDynamicToDto(model, rackDto);
                        var rackClient = _ClientFactory.CreateClient<RackDto>($"{serviceUrl}Rack");
                        await rackClient.UpdateAsync((Guid)model.Guid, rackDto);
                        break;

                    case "simcarddto":
                        var simcardDto = new SimcardDto();
                        MapDynamicToDto(model, simcardDto);
                        var simcardClient = _ClientFactory.CreateClient<SimcardDto>($"{serviceUrl}Simcard");
                        await simcardClient.UpdateAsync((Guid)model.Guid, simcardDto);
                        break;

                    case "softwaredto":
                        var softwareDto = new SoftwareDto();
                        MapDynamicToDto(model, softwareDto);
                        var softwareClient = _ClientFactory.CreateClient<SoftwareDto>($"{serviceUrl}Software");
                        await softwareClient.UpdateAsync((Guid)model.Guid, softwareDto);
                        break;

                    default:
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       


        [HttpGet]
        public async Task<IActionResult> Delete(string type, Guid id)
        {
            var item = await GetDetailsAsync(type, id);
            if (item == null)
            {
                return NotFound();
            }
            return View("GenericDelete", item);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(string type, Guid guid)
        {
            var result = await DeleteItemAsync(type, guid);
            if (result)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Delete failed.");
            var item = await GetDetailsAsync(type, guid);
            return View("GenericDelete", item);
        }



        private async Task<bool> DeleteItemAsync(string type, Guid id)
        {
            switch (type.ToLower())
            {
                case "computerdto":
                    var computerClient = _ClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                    await computerClient.DeleteAsync(id);
                    break;
                case "cabledto":
                    var cableClient = _ClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                    await cableClient.DeleteAsync(id);
                    break;
                case "devicedto":
                    var deviceClient = _ClientFactory.CreateClient<DeviceDto>($"{serviceUrl}Device");
                    await deviceClient.DeleteAsync(id);
                    break;
                case "monitordto":
                    var monitorClient = _ClientFactory.CreateClient<MonitorDto>($"{serviceUrl}Monitor");
                    await monitorClient.DeleteAsync(id);
                    break;
                case "pdudto":
                    var pduClient = _ClientFactory.CreateClient<PDUDto>($"{serviceUrl}PDU");
                    await pduClient.DeleteAsync(id);
                    break;
                case "phonedto":
                    var phoneClient = _ClientFactory.CreateClient<PhoneDto>($"{serviceUrl}Phone");
                    await phoneClient.DeleteAsync(id);
                    break;
                case "printerdto":
                    var printerClient = _ClientFactory.CreateClient<PrinterDto>($"{serviceUrl}Printer");
                    await printerClient.DeleteAsync(id);
                    break;
                case "rackdto":
                    var rackClient = _ClientFactory.CreateClient<RackDto>($"{serviceUrl}Rack");
                    await rackClient.DeleteAsync(id);
                    break;
                case "simcarddto":
                    var simcardClient = _ClientFactory.CreateClient<SimcardDto>($"{serviceUrl}Simcard");
                    await simcardClient.DeleteAsync(id);
                    break;
                case "softwaredto":
                    var softwareClient = _ClientFactory.CreateClient<SoftwareDto>($"{serviceUrl}Software");
                    await softwareClient.DeleteAsync(id);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
