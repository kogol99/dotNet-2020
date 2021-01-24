using System;
using System.ComponentModel.DataAnnotations;

namespace dotNet_Lista11.ViewModels
{
    public enum Category
    {
        User, Mod, Admin
    }
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole adres e-mail jest wymagane")]
        [MinLength(6, ErrorMessage = "Za krótki adres e-mail")]
        [Display(Name = "Adres e-mail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Podano nieprawidłowy email. Poprawny email to np. pwr@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane")]
        [MinLength(1, ErrorMessage = "Zbyt krótka nazwa.")]
        [Display(Name = "Nazwa")]
        [MaxLength(40, ErrorMessage = " Za długa nazwa, nie przekraczaj {0} znaków")]
        [RegularExpression(@"[A-Z][a-zA-z\u00d3-\u017c\s\-]+", ErrorMessage = "Podano nieprawidłową nazwę. Dopuszczalne są tylko litery, '-' oraz spacja.") ]
        public string Name { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Pole kode pocztowy jest wymagane.")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Kod pocztowy musi być formatu 00-000")]
        public string Postcode { get; set; }

        [Display(Name = "Kategoria konta")]
        [Required(ErrorMessage = "Pole kategoria konta jest wymagane.")]
        public Category Category { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(string email, string name, string postcode, Category category)
        {
            this.Email = email;
            this.Name = name;
            this.Postcode = postcode;
            this.Category = category;
        }
    }

}
