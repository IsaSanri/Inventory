namespace InventorySystem.Entities.DTOs
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
