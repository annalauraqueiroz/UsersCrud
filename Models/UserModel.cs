using System.ComponentModel.DataAnnotations;

namespace CRUDUsuarios.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } 
        [DataType(DataType.PhoneNumber)]
        [EmailAddress(ErrorMessage = "Telfone inválido")]
        public string PhoneNumber { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Imagem { get; set; }

    }
}
