﻿using Microsoft.AspNetCore.Mvc;
using Product_catalog_with_categories_WebAPI.Data;

namespace Product_catalog_with_categories_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputersController : Controller
    {
        private readonly CatalogDbContext _catalogDbContext;
        public ComputersController(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;

        }

        [HttpGet]
        public List<Data.Computer> Get()
        {

            var Computers = _catalogDbContext.Computers.ToList();

            return Computers;
        }

        [HttpGet("{id}")]
        public Data.Computer Get(int id)
        {

            var Computers = _catalogDbContext.Computers.FirstOrDefault(x => x.Id == id);

            return Computers;
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, Data.Computer Computer)
        {
            var existComputer = _catalogDbContext.Computers.FirstOrDefault(x => x.Id == id);
            if (existComputer == null)
            {
                return NotFound();
            }
            existComputer.BrandName = Computer.BrandName;
            existComputer.Model = Computer.Model;
            existComputer.ComputerId = Computer.ComputerId;
            existComputer.Price = Computer.Price;
         

            _catalogDbContext.Computers.Update(existComputer);
            _catalogDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Data.Computer Computer)
        {
            _catalogDbContext.Computers.Add(Computer);
            _catalogDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existComputer = _catalogDbContext.Computers.FirstOrDefault(x => x.Id == id);
            if (existComputer == null)
            {
                return NotFound();
            }


            _catalogDbContext.Computers.Remove(existComputer);
            _catalogDbContext.SaveChanges();

            return Ok();
        }
    }
}
