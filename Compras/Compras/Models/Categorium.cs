using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Compras.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Categoriaproveedors = new HashSet<Categoriaproveedor>();
            Productos = new HashSet<Producto>();
        }

        public int Idcategoria { get; set; }
        public string Nombrecategoria { get; set; }
        [JsonIgnore]
        public virtual ICollection<Categoriaproveedor> Categoriaproveedors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
