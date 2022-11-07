using Product_catalog_with_categories_WebAPI.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Product_catalog_with_categories_WebAPI.Data
{
    public class Electronic
    {
        [Key]
        public int Id { get; set; }
        public string Categories { get; set; }
        public int ElectonicId { get; set; }


    }
}
