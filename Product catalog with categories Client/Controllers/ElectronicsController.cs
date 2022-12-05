using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Product_catalog_with_categories_Client.Models;
using Product_catalog_with_categories_Client.Models.Config;
using Product_catalog_with_categories_Client.Services;
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

        private readonly ProductCatalogService _productCatalogService;

        public ElectronicsController(ILogger<ElectronicsController> logger, ProductCatalogService productCatalogService)
        {
            _logger = logger;
            _productCatalogService = productCatalogService;
        }

        public async Task<IActionResult> Index()
        {
            List<Electronic> Electronic = await _productCatalogService.GetElectronics();
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
            await _productCatalogService.RemoveElectronic(Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Electronic electronic)
        {
            bool result = await _productCatalogService.EditElectronic(electronic);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(electronic);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var electronic = await _productCatalogService.GetElectronic(Id);

            return View(electronic);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Electronic electronic)
        {
            bool result = await _productCatalogService.AddElectronic(electronic);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

    }
}