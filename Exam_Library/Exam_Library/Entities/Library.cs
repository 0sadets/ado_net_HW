using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
