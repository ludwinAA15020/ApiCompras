using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Personalclave
    {
        public int Idpersonalclave { get; set; }
        public int Idperfil { get; set; }
        public string Nombrepersonal { get; set; }
        public string Cargopersonal { get; set; }
        public string Firmapersonal { get; set; }
        [JsonIgnore]
        public virtual Perfil IdperfilNavigation { get; set; }
    }
}
