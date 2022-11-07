using Microsoft.AspNetCore.Mvc;
using Product_catalog_with_categories_WebAPI.Data;

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
        public List<Data.Electronic> Get()
        {

            var Electronics = _catalogDbContext.Electronics.ToList();

            return Electronics;
        }

        [HttpGet("{id}")]
        public Data.Electronic Get(int id)
        {

            var Electronic = _catalogDbContext.Electronics.FirstOrDefault(x =>x.Id == id);

            return Electronic;
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, Data.Electronic electronic)
        {
            var existElectronic = _catalogDbContext.Electronics.FirstOrDefault(x => x.Id == id);
            if(existElectronic == null)
            {
                return NotFound();
            }
            existElectronic.Categories = electronic.Categories;
            existElectronic.ElectonicId = electronic.ElectonicId;

            _catalogDbContext.Electronics.Update(existElectronic);
            _catalogDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Data.Electronic electronic)
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
