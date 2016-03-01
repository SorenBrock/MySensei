using System;
using System.ComponentModel.DataAnnotations;

namespace mysensei.Models
{
    public class PersonMetadata
    {
        [Required]
        [Display(Name = "Brugernavn")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Brugernavn skal minimum være 4 tegn")]
        public string Username;

        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Password skal minimum være 4 tegn")]
        public string Password;

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email;

    }
    public class LocationGroupMetadata
    {
        [Required(ErrorMessage = "Indtast venligt skemanavn")]
        [Display(Name = "Post Skema")]
        public string Name;

        [Required]
        [Display(Name = "Post start")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Skal være et postnr")]
        public string ZipcodeStart;


        [Required]
        [Display(Name = "Post slut")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Skal være et postnr")]
        public string ZipcodeEnd;

    }


}