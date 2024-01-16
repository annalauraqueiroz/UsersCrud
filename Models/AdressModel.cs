using System.ComponentModel.DataAnnotations;

namespace CRUDUsuarios.Models
{
    public class AdressModel
    {
        public int AdressId { get; set; }
        public string AdressName { get; set;}
        public string Number { get; set;}

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "CEP")]
        public string CEP { get; set;}

        [Display(Name = "Complemento")]
        public string Details { get; set;}
        public string City { get; set;}
        public int StateId { get; set;}
    }
}
