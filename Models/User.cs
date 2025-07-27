using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O Username não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O Username deve ter pelo menos 3 caracteres.")]
        public string Username { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Password não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "Password deve ter pelo menos 3 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}