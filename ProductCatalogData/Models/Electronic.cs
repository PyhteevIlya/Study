using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogData.Models
{
    public class Electronic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ElectronicType Type { get; set; }

    }
}
