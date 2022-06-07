using System;


namespace InventorySystem.Entities.DTOs
{
    public class MovimientoCreateDto
    {
       
        public DateTime Fecha { get; set; }
        public int IdArticulo{ get; set; }
        public int Cantidad { get; set; }
        public string Concepto { get; set; }
        public string Estado { get; set; }
        public int TipoDeMovimiento { get; set; }
    }
}
