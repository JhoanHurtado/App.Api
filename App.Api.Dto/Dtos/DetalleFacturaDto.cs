namespace App.Api.Dto.Dtos
{
    public class DetalleFacturaDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string IdCliente { get; set; }
        public int IdFactura { get; set; }
        public float Cantidad { get; set; }
        public float Subtotal { get; set; }

        public virtual ClienteDto Cliente { get; set; }
        public virtual ProductoDto Producto { get; set; }
        public virtual FacturaDto Factura { get; set; }
    }
}
