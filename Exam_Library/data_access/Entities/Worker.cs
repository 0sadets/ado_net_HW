using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary {  get; set; }
        public string Position {  get; set; }
        public int LibraryId {  get; set; }
        public string Login { get; set; } 
        public string Password { get; set; } 
        public Library Library { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
