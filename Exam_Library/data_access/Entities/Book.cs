using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Publisher {  get; set; }
        public int NumberOfPages {  get; set; }
        public string Genre {  get; set; }
        public int Year { get; set; }
        public decimal Cost {  get; set; }
        public decimal Price {  get; set; }
        public bool IsSequel {  get; set; } // продовження
        public bool HasDiscount {  get; set; }
        public string Status {  get; set; }// available, sold, reserved
        public int Count {  get; set; }
        public int Rating {  get; set; }
        public int LibraryId {  get; set; }
        public Library Library { get; set; }
        public ICollection<Reserved> Reserveds { get; set; }
        public ICollection<Action> Actions { get; set; } // Discounts
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
