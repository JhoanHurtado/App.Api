using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Model.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string IdCliente { get; set; }
        public int IdFactura { get; set; }
        public float Cantidad { get; set; }
        public float Subtotal { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
