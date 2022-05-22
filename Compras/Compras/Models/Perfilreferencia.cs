using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Perfilreferencia
    {
        public int Idperfil { get; set; }
        public int Idreferencia { get; set; }
        [JsonIgnore]
        public virtual Perfil IdperfilNavigation { get; set; }
        [JsonIgnore]
        public virtual Referencium IdreferenciaNavigation { get; set; }
    }
}
