using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_catalog_with_categories_Client.Models;
using Product_catalog_with_categories_Client.Services;
using ProductCatalogData.Models;
using System.Diagnostics;

namespace Product_catalog_with_categories_Client.Controllers
{
    public class ComputersController : Controller
    {
        private readonly ILogger<ComputersController> _logger;

        private readonly ProductCatalogService _productCatalogService;

        public ComputersController(ILogger<ComputersController> logger, ProductCatalogService productCatalogService)
        {
            _logger = logger;
            _productCatalogService = productCatalogService;
        }


        public async Task<IActionResult> Index()
        {
            List<Computer> Computer = await _productCatalogService.GetComputers();
            return View(Computer);



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
            await _productCatalogService.RemoveComputer(Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Computer computer)
        {
            bool result = await _productCatalogService.EditComputer(computer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View((computer, await GetElectronicsSelectList()));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var computer = await _productCatalogService.GetComputer(Id);
            var electronics = await GetElectronicsSelectList();
            return View((computer, electronics));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Computer computer)
        {
            bool result = await _productCatalogService.AddComputer(computer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(await GetElectronicsSelectList());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(await GetElectronicsSelectList());
        }

        private async Task<SelectList> GetElectronicsSelectList()
        {
            List<Electronic> Electronic = await _productCatalogService.GetElectronics();
            return new SelectList(Electronic, "Id", "Name");
        }
    }
}