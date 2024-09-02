using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice {  get; set; }

    }
}
