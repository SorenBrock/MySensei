using System.ComponentModel.DataAnnotations;

namespace mysensei.Models.ViewModels
{
    public class ViewModelProfile
    {
        [Required(ErrorMessage = "Indtast venligst fornavn")]
        [Display(Name = "Indtast fornavn (*)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Indtast venligst efternavn")]
        [Display(Name = "Indtast efternavn (*)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = @"Indtast venligst adresse")]
        [Display(Name = "Indtast adresse (*)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Indtast venligst postnr")]
        [Display(Name = "Indtast postnummer (*)")]
        [RegularExpression(@"^([1-9]\d{3})$", ErrorMessage = "Postnr skal være mellem 1000 til 9999")]
        public string Zipcode { get; set; }

        [Display(Name = "By")]
        public string City { get; set; }

        [Display(Name = "Indtast telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Indtast venligst brugernavn")]
        [Display(Name = "Indtast brugernavn (*)")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Brugernavn skal minimum være 4 tegn")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Indtast venligst Password")]
        [StringLength(25, ErrorMessage = "Password skal minimum være {2} karakter", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Indtast password (*)")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Indtast venligst Password")]
        [StringLength(25, ErrorMessage = "Password skal minimum være {2} karakter", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Gentag Password (*)")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Indtast email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email er ikke korrekt")]
        [EmailAddress]
        public string Email { get; set; }
    }
}