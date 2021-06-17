using App.Api.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Model.Models
{
    public class Cliente
    {
        [Key, Required(ErrorMessage = "Identificacion requerid!."), StringLength(16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Identificador { get; set; }

        [Required(ErrorMessage ="El nombre es requerido"), StringLength(128)]
        public string NombreCompleto { get; set; } 

        public EstadoEnum Estado { get; set; }
    }
}
