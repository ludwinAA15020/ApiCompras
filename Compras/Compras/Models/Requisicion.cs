using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Requisicion
    {
        public Requisicion()
        {
            Cotizacions = new HashSet<Cotizacion>();
            Productorequisicions = new HashSet<Productorequisicion>();
        }

        public int Idrequisicion { get; set; }
        public int Idusuario { get; set; }
        public DateTime Fechacreada { get; set; }
        public string Nivelimportancia { get; set; }
        public DateTime Fechaestimada { get; set; }
        public int Cantidadproducto { get; set; }
        [JsonIgnore]
        public virtual Usuario IdusuarioNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Productorequisicion> Productorequisicions { get; set; }
    }
}
