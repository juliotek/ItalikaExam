using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItlaikaProjectAPI.Models.RequestModels
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Sku { get; set; }
        public string Fert { get; set; }
        public int IdType { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Serie { get; set; }
        public DateTime? Date { get; set; }
        public bool Status { get; set; }
    }
}
