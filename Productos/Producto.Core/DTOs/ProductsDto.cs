using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.DTOs
{
    public class ProductsDto
    {
        public int Product_Id { get; set; }
        [Required]
        //Descripcion
        public string Descripcion { get; set; }
        [Required]
        //Estado del Producto
        public string Estado_Producto { get; set; }
        [Required]
        //Fecha de Fabricacion
        public DateTime? Fecha_Fabricacion { get; set; }
        [Required]
        //Fecha de validez
        public DateTime? Fecha_Validez { get; set; }
        [Required]
        //Codigo del Proveedor
        public int Codigo_Proveedor { get; set; }
    }
}
