using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Sucursal
    {
        public int Idsucursal { get; set; }
        public int Idperfil { get; set; }
        public string Ubicacionsucursal { get; set; }
        public string Imagensucursal { get; set; }
        [JsonIgnore]
        public virtual Perfil IdperfilNavigation { get; set; }
    }
}
