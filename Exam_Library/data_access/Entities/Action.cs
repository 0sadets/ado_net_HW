using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public float DiscountPercentage {  get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
