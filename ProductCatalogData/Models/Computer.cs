using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogData.Models
{
    public class Computer : IItem
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        //public int ComputerId { get; set; }

        //public ComputerType Type { get; set; }

        [ForeignKey(nameof(Electronic))]
        public int ElectronicId { get; set; }

        public Electronic? Electronic { get; set; }

    }
}
