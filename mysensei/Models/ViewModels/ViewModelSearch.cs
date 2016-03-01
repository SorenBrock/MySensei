using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mysensei.Models.ViewModels
{
    public class ViewModelSearch
    {
        public int Take { get; set; }
        public int PageAll { get; set; }
        public int PageThis { get; set; }
        public int RecordCount { get; set; }
        public string SearchField { get; set; }
        public SelectList TakeList = new SelectList(new int[] { 20, 50, 100, 200 });
        public bool Root  { get; set; }

        public IQueryable<Course> ListCourses { get; set; }    
        public IEnumerable<Tag> ListTags { get; set; }
        public IEnumerable<TagGroup> ListTagGroups { get; set; }
        public IEnumerable<LocationGroup> ListLocationGroups { get; set; }

        public int LocationGroupId { get; set; }


    }
}