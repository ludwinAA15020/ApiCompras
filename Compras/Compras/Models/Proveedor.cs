using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Categoriaproveedors = new HashSet<Categoriaproveedor>();
            Cotizacions = new HashSet<Cotizacion>();
            Perfils = new HashSet<Perfil>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idproveedores { get; set; }
        public int? Idperfil { get; set; }
        public string Nombreproveedor { get; set; }
        public string Representante { get; set; }
        public string Direccioncompania { get; set; }
        public string Telefonocompania { get; set; }
        public string Faxcompania { get; set; }
        public string Movilcompania { get; set; }
        public string Email { get; set; }
        public int? ContactosLista { get; set; }
        public string Website { get; set; }
        public int Tipoorganizacion { get; set; }
        public string Nit { get; set; }
        public string Nrc { get; set; }
        public int Rubro { get; set; }
        public string Calificacion { get; set; }
        [JsonIgnore]
        public virtual Perfil IdperfilNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Categoriaproveedor> Categoriaproveedors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Perfil> Perfils { get; set; }
        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
