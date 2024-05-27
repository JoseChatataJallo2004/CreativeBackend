namespace Backend.Modelo
{
    public class Detalle_Venta_Model
    {
        public int iddetalleventa { get; set; }
        public string producto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
