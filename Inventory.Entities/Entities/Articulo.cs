using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities.Entities
{
    public class Articulo
    {
        
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida{ get; set; }
        public string CodigoBarra { get; set; }
        public int SaldoExistencia { get; set; }
        public string Estado { get; set; }
    }
}
