using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Api.Model.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [StringLength(16)]
        public string IdentificadorCliente { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public float Total { get; set; }

        [StringLength(16)]
        [ForeignKey("IdentificadorCliente")]
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
