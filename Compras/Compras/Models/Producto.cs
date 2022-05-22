using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Productorequisicions = new HashSet<Productorequisicion>();
        }

        public int Idproducto { get; set; }
        public int Idcategoria { get; set; }
        public string Nombreprod { get; set; }
        public double Precioprod { get; set; }
        public string Medidasprod { get; set; }
        public string Marcaprod { get; set; }
        public string Utilidadprod { get; set; }
        public string Descripcionprod { get; set; }
        public string Garantiaprod { get; set; }
        public string Imagenprod { get; set; }
        [JsonIgnore]
        public virtual Categorium IdcategoriaNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Productorequisicion> Productorequisicions { get; set; }
    }
}
