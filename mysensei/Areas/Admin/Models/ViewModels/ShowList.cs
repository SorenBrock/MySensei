using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using mysensei.Models;

namespace mysensei.Areas.Admin.Models.ViewModels
{
    public class ShowList<T>
    {
        public int Take { get; set; }
        public int PageAll { get; set; }
        public int PageThis { get; set; }
        public int RecordCount { get; set; }
        public string SearchField { get; set; }
        public SelectList TakeList = new SelectList(new int[] { 20, 50, 100, 200 });

        public IEnumerable<T> ListGeneric { get; set; }

    }
}