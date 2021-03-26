using System;
using System.Collections.Generic;

#nullable disable

namespace ItlaikaProjectAPI.Models
{
    public partial class TbProduct
    {
        public int IdProduct { get; set; }
        public string Sku { get; set; }
        public string Fert { get; set; }
        public string Model { get; set; }
        public int IdType { get; set; }
        public string Serie { get; set; }
        public DateTime? Date { get; set; }
        public bool Status { get; set; }

        public virtual CType IdTypeNavigation { get; set; }
    }
}
