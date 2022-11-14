using Microsoft.AspNetCore.Mvc;
using Product_catalog_with_categories_WebAPI.Data;
using ProductCatalogData.Models;

namespace Product_catalog_with_categories_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectronicsController : Controller
    {
        private readonly CatalogDbContext _catalogDbContext;
        public ElectronicsController(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;

        }

        [HttpGet]
        public List<Electronic> Get()
        {

            var Electronics = _catalogDbContext.Electronics.ToList();

            return Electronics;
        }

        [HttpGet("{id}")]
        public Electronic Get(int id)
        {

            var Electronic = _catalogDbContext.Electronics.FirstOrDefault(x =>x.Id == id);

            return Electronic;
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, Electronic electronic)
        {
            var existElectronic = _catalogDbContext.Electronics.FirstOrDefault(x => x.Id == id);
            if(existElectronic == null)
            {
                return NotFound();
            }
            existElectronic.Name = electronic.Name;
            existElectronic.Type = electronic.Type;

            _catalogDbContext.Electronics.Update(existElectronic);
            _catalogDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Electronic electronic)
        {
            _catalogDbContext.Electronics.Add(electronic);
            _catalogDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existElectronic = _catalogDbContext.Electronics.FirstOrDefault(x => x.Id == id);
            if (existElectronic == null)
            {
                return NotFound();
            }
      

            _catalogDbContext.Electronics.Remove(existElectronic);
            _catalogDbContext.SaveChanges();

            return Ok();
        }
    }
}
