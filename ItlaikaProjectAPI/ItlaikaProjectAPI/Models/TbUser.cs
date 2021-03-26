using System;
using System.Collections.Generic;

#nullable disable

namespace ItlaikaProjectAPI.Models
{
    public partial class TbUser
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public bool Status { get; set; }
    }
}
