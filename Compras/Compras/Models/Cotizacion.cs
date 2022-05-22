using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            Ordencompras = new HashSet<Ordencompra>();
        }

        public int Idcotizacion { get; set; }
        public int Idrequisicion { get; set; }
        public int Idproveedores { get; set; }
        public int? Idordencompra { get; set; }
        public int Idmetodopago { get; set; }
        public double Precio { get; set; }
        public DateTime Fechacotizacion { get; set; }
        [JsonIgnore]
        public virtual Metodopago IdmetodopagoNavigation { get; set; }
        [JsonIgnore]
        public virtual Ordencompra IdordencompraNavigation { get; set; }
        [JsonIgnore]
        public virtual Proveedor IdproveedoresNavigation { get; set; }
        [JsonIgnore]
        public virtual Requisicion IdrequisicionNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ordencompra> Ordencompras { get; set; }
    }
}
