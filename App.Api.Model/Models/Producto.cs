using System.ComponentModel.DataAnnotations;

namespace App.Api.Model.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Descripcion { get; set; }
    }
}
