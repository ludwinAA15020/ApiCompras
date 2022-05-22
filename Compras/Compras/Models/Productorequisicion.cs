using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Productorequisicion
    {
        public int Idproducto { get; set; }
        public int Idrequisicion { get; set; }
        [JsonIgnore]
        public virtual Producto IdproductoNavigation { get; set; }
        [JsonIgnore]
        public virtual Requisicion IdrequisicionNavigation { get; set; }
    }
}
