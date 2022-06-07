using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities.DTOs
{
    public class ArticuloSaldoExistenciaDto
    {
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public int SaldoExistencia { get; set; }
    }
}
