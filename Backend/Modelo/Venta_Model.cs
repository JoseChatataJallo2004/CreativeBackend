namespace Backend.Modelo
{
    public class Venta_Model
    {
        public int Idventa { get; set; }
        public string numerodocumento { get; set; }
        public decimal Total { get; set; }



        public List<Detalle_Venta_Model> LSTDetalleventa { get; set; }
    }
}
