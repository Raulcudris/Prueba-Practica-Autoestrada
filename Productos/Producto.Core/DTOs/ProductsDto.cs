using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.DTOs
{
    public class ProductsDto
    {
        //Descripcion del Producto
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
