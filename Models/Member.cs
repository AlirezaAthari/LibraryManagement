using System.Collections.Generic;

namespace wpf_start.Models
{
    public class Member :  Manager
    {
        public List<Book> Books { get; set; }
    }
}