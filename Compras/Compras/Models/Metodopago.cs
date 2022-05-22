using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Metodopago
    {
        public Metodopago()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Idmetodopago { get; set; }
        public string Nombretipo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
