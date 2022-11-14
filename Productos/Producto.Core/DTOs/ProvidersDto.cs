using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.DTOs
{
    public class ProvidersDto
    {
        public int Id { get; set; }
        //Nombre del Proveedor
        [Required]
        public string Nombre { get; set; }
        [Required]
        //Descripcion del proveedor
        public string Descripcion { get; set; }
        [Required]
        //Telefono de proveedor
        public string Telefono { get; set; }
    }
}
