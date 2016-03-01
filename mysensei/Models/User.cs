using System;

namespace mysensei.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String UserName { get; set; }
        public bool IsAdmin = false;
        public bool RememberMe { get; set; }
    }
}