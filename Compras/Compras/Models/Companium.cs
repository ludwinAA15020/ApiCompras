using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Companium
    {
        public int Idcompania { get; set; }
        public int Idperfil { get; set; }
        public string Nombrecompania { get; set; }
        public string Valorcompania { get; set; }
        public string Contactocomania { get; set; }
        public string Telefonocompania { get; set; }
        [JsonIgnore]
        public virtual Perfil IdperfilNavigation { get; set; }
    }
}
