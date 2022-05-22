using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Requisicions = new HashSet<Requisicion>();
        }

        public int Idusuario { get; set; }
        public int Idrol { get; set; }
      
        public int? Idproveedores { get; set; }
        public string Nombreusuario { get; set; }
      
        public string Correo { get; set; }
        public string Contra { get; set; }
        [JsonIgnore]
        public virtual Proveedor IdproveedoresNavigation { get; set; }
        [JsonIgnore]
        public virtual Role IdrolNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Requisicion> Requisicions { get; set; }
    }
}
