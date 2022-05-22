using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Categoriaproveedor
    {
        public int Idproveedores { get; set; }
        public int Idcategoria { get; set; }
        [JsonIgnore]
        public virtual Categorium IdcategoriaNavigation { get; set; }
        [JsonIgnore]
        public virtual Proveedor IdproveedoresNavigation { get; set; }
    }
}
