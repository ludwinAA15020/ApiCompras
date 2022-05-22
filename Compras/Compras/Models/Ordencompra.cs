using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Ordencompra
    {
        public Ordencompra()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Idordencompra { get; set; }
        public int Idcotizacion { get; set; }
        public DateTime Fechacotizacion { get; set; }
        [JsonIgnore]
        public virtual Cotizacion IdcotizacionNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
