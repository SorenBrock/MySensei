using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysensei.Areas.Admin.Models.ViewModels
{
    public class VisitedPage
    {
        public VisitedPage(string pageAction, int pageId)
        {
            this.PageAction = pageAction;
            this.PageId = pageId;
        }
        public string PageAction { get; set; }
        public int PageId { get; set; }
     
    }
}