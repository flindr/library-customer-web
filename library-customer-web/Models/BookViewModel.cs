using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }
        public string Author { get; set; }
    }
}
