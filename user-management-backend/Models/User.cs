using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace user_management_backend.Models
{
    public class User
    {
        [Key] // Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental
        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")] // No puede estar vacío
        public string Name { get; set; }

        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120")] // Validación de edad Valida que la edad esté entre 0 y 120
        public int Age { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")] // Valida formato de email
        public string Email { get; set; }
    }
}
