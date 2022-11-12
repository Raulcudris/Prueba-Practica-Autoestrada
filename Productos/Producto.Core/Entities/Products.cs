using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Entities
{
     public  class Products
      {
        //Codigo del Producto
        public int Codigo_Producto { get; set; }
        //Codigo del Descripcion
        public string Descripcion { get; set; }
        //Estado del Producto
        public string Estado_Producto { get; set; }
        //Fecha de Fabricacion
        public DateTime Fecha_Fabricacion { get; set; }
        //Fecha de validez
        public DateTime Fecha_Validez { get; set; }
        //Codigo del Proveedor
        public int Codigo_Proveedor { get; set; }

    }
}
