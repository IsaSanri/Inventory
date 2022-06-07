using System;

namespace InventorySystem.Entities.Entities
{
    public class Movimiento

    {
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int IdArticulo{ get; set; }
        public int Cantidad { get; set; }
        public string Concepto { get; set; }
        public string Estado { get; set; }
        public int TipoDeMovimiento { get; set; }
    }
}
