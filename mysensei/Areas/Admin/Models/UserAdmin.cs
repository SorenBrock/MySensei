using System;

namespace mysensei.Areas.Admin.Models
{
    public class UserAdmin
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String UserName { get; set; }
        public bool IsAdmin = true;
    }
}