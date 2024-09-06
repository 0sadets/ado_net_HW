using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Reserved
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ClientId {  get; set; }
        public Client Client { get; set; }
        public DateTime DateOfReservetion { get; set; }
        public string Status { get; set; } // active, completed
    }
}
