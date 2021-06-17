using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Api.Dto.Dtos
{
    public class FacturaDto
    {
        public int Id { get; set; }
        [StringLength(16)]
        public string IdentificadorCliente { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public float Total { get; set; }

        [StringLength(16)]
        public virtual ClienteDto Cliente { get; set; }
        public virtual ICollection<DetalleFacturaDto> DetalleFacturas { get; set; }
    }
}
