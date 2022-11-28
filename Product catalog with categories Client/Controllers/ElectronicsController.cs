﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Product_catalog_with_categories_Client.Models;
using Product_catalog_with_categories_Client.Models.Config;
using ProductCatalogData.Models;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;

namespace Product_catalog_with_categories_Client.Controllers
{
    public class ElectronicsController : Controller
    {
        private readonly ILogger<ElectronicsController> _logger;

        private readonly IOptions<ProductcatalogwithcategoriesWebAPIConfig> _pcWebAPIConfig;

        public ElectronicsController(ILogger<ElectronicsController> logger, IOptions<ProductcatalogwithcategoriesWebAPIConfig> pcWebAPIConfig)
        {
            _logger = logger;
            _pcWebAPIConfig = pcWebAPIConfig;
        }

        public async Task<IActionResult> Index()
        {
            List<Electronic> Electronic = await GetElectronic();
            return View(Electronic);



            //using (var httpClient = new HttpClient())
            //{
            //    //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");

            //    var response = await httpClient.GetAsync((string)_pcWebAPIConfig.Value.Endpoint + "Electronic");
            //        //new StringContent(jsonData), Encoding.UTF8, "application/json"));

            //    var responseData = await response.Content.ReadAsStringAsync();

            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var result = JsonConvert.DeserializeObject<List<Electronic>>(responseData);

            //        return result;
            //    }
            //    return null;

            //}


            //    List<Electronic> electronics = new List<Electronic>();
            //return View(electronics);
        }


        public async Task<IActionResult> Remove(int Id)
        {
            await RemoveElectronic(Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Electronic electronic)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Electronic electronic)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        private async Task<bool> RemoveElectronic(int Id)
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(5);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.DeleteAsync((string)_pcWebAPIConfig.Value.Endpoint + "Electronics/" + Id);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch { }
            return false;
        }


        private async Task<List<Electronic>> GetElectronic()
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(10);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.GetAsync((string)_pcWebAPIConfig.Value.Endpoint + "Electronics");
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<List<Electronic>>(responseData);

                    return result;
                }

            }
            catch {  }
                return null;
        }
        
    }
}