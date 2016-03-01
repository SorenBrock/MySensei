using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mysensei.Models.ViewModels
{
    public class ViewModelLogin
    {
        [Required(ErrorMessage = "Indtast brugernavn")]
        [RegularExpression("^[A-Za-z0-9_]+$", ErrorMessage = "Du må kun bruge a-z / 0-9 i brugernavn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Indtast password")]
        [RegularExpression("^[A-Za-z0-9_]+$", ErrorMessage = "Du må kun bruge a-z / 0-9 i password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public bool RememberMe { get; set; }

    }
}