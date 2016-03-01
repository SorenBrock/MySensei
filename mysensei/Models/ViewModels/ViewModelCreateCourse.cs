using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mysensei.Models.ViewModels
{
    public class ViewModelCreateCourse
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Indtast venligst kursusnavn")]
        [Display(Name = "Indtast navn kursusnavn")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Indtast venligst beskrivelse")]
        [Display(Name = "Indtast beskrivelse")]
        public string Description { get; set; }

        //public string JsonTag { get; set; }
        //public IEnumerable<Tag> ListTags { get; set; }

    }
}