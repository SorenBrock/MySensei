using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysensei.Models.ViewModels
{
    public class ViewModelDiscover
    {
        public IEnumerable<Course> ListCoursesHighRating { get; set; }
        public IEnumerable<Course> ListCoursesNew { get; set; }
        public IEnumerable<Course> ListCoursesPrivate { get; set; }
    }
}