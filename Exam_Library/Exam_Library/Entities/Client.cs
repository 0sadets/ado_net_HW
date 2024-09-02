using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int LibraryId {  get; set; }
        public Library Library { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Reserved> Reserved { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
