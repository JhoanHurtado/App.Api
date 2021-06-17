using System.ComponentModel.DataAnnotations;

namespace App.Api.Dto.Dtos
{
    public class ClienteDto
    {
        [Key, Required(ErrorMessage = "Identificacion requerid!."), StringLength(16)]
        public string Identificador { get; set; }

        [Required(ErrorMessage = "El nombre es requerido"), StringLength(128)]
        public string NombreCompleto { get; set; }

    }
}
