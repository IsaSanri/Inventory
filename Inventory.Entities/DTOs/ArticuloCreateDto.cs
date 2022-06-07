using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.DTOs
{
    public class ArticuloCreateDto
    {
        
        public string Descripcion { get; set; }
        public string UnidadMedida{ get; set; }
        public string CodigoBarra { get; set; }
        public int SaldoExistencia { get; set; }
        public string Estado { get; set; }
    }
}
