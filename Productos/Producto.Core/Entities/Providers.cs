using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Entities
{
    public class Providers : BaseEntityProvider
    {
        //Codigo del Proveedor
        public int Provedor_Id { get; set; }
        //Nombre del Proveedor
        public string Nombre { get; set; }
        //Descripcion del proveedor
        public string Descripcion { get; set; }
        //Telefono de proveedor
        public string Telefono { get; set; }

    }
}
