using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItalikaProjectMVC.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Sku { get; set; }
        public string Fert { get; set; }
        public int IdModel { get; set; }
        public string strModel { get; set; }
        public string Serie { get; set; }
        public DateTime? Date { get; set; }
        public bool Status { get; set; }
    }
}
