using System;
using System.Collections.Generic;

#nullable disable

namespace ItlaikaProjectAPI.Models
{
    public partial class CType
    {
        public CType()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int IdType { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
