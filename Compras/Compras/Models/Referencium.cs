using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Referencium
    {
        public Referencium()
        {
            Perfilreferencia = new HashSet<Perfilreferencia>();
        }

        public int Idreferencia { get; set; }
        public string Tiporeferencia { get; set; }
        public string Nombrecompania { get; set; }
        public string Nombrecontacto { get; set; }
        public string Telefonocontacto { get; set; }
        [JsonIgnore]
        public virtual ICollection<Perfilreferencia> Perfilreferencia { get; set; }
    }
}
