using System.ComponentModel.DataAnnotations;

namespace CRUDUsuarios.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Contato")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}
