using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Api.Dto.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Descripcion { get; set; }
    }
}
