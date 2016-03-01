using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysensei.Models.ViewModels
{
    public class ViewModelSearchResult
    {
        public IQueryable<Course> ListCourses { get; set; }
        public IEnumerable<Tag> ListTags { get; set; }
        public IEnumerable<TagGroup> ListTagGroups { get; set; }
    }
}