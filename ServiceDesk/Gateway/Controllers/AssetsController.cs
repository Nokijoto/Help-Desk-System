﻿using CrudBase;
using Gateway.Clients;
using Gateway.Enums;
using Gateway.Factories;
using Gateway.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace Gateway.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetClientFactory _assetClientFactory;
        private readonly String serviceUrl = "http://localhost:5256/api/";
        public AssetsController(IAssetClientFactory assetClientFactory)
        {
            _assetClientFactory = assetClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Computers()
        {
            var Client = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
            var items = await Client.GetAllAsync();
            return View("GenericView", items);
         
        }

        [HttpGet]
        public async Task<IActionResult> Cables()
        {

            var Client = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
            var items = await Client.GetAllAsync();
            return View("GenericView", items);

        }

        [HttpGet]
        public async Task<IActionResult> Phone()
        {

            var Client = _assetClientFactory.CreateClient<PhoneDto>($"{serviceUrl}Phone");
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
                    var computerClient = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                    return await computerClient.GetByIdAsync(id);
                case "cable":
                    var cableClient = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                    return await cableClient.GetByIdAsync(id);
                default:
                    return null;
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
                        var computerClient = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                        await computerClient.UpdateAsync((Guid)model.Guid, computerDto);
                        return true;

                    case "cabledto":
                        var cableDto = new CableDto();
                        MapDynamicToDto(model, cableDto);
                        var cableClient = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                        await cableClient.UpdateAsync((Guid)model.Guid, cableDto);
                        return true;

                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

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
                    var computerClient = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                    await computerClient.DeleteAsync(id);
                    return true;
                case "cabledto":
                    var cableClient = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                    await cableClient.DeleteAsync(id);
                    return true;
                default:
                    return false;
            }
        }
    }
}
