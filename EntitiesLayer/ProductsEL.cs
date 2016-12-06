using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class ProductsEL
    {
        public int idProducto { get; set; }
        public String descripcionProducto { get; set; }
        public String detalleProducto { get; set; }
        public String tiempoElab { get; set; }
        public double incrementoxProduccion { get; set; }
        public Boolean disponibilidad { get; set; }
        public double cantidadDisponible { get; set; }
        public CategoriesEL Categoria { get; set; }
        public String imagen { get; set; }
    }
}
