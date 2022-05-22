using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Compania = new HashSet<Companium>();
            Perfilreferencia = new HashSet<Perfilreferencia>();
            Personalclaves = new HashSet<Personalclave>();
            Proveedors = new HashSet<Proveedor>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Idperfil { get; set; }
        public int Idproveedores { get; set; }
        public string Nombreceo { get; set; }
        public string Nombregerente { get; set; }
        public string DirectorareaLista { get; set; }
        public string Escritura { get; set; }
        public string Razonsocial { get; set; }
        [JsonIgnore]
        public virtual Proveedor IdproveedoresNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Companium> Compania { get; set; }
        [JsonIgnore]
        public virtual ICollection<Perfilreferencia> Perfilreferencia { get; set; }
        [JsonIgnore]
        public virtual ICollection<Personalclave> Personalclaves { get; set; }
        [JsonIgnore]
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
