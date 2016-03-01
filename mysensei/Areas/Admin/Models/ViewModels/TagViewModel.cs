using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mysensei.Models;

namespace mysensei.Areas.Admin.Models.ViewModels
{
    public class TagViewModel
    {

        public Tag TagModel { get; set; }
        public IEnumerable<TagGroup> TagGroupToAdd { get; set; }
    }
}