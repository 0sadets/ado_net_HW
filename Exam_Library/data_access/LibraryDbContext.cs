using Exam_Library.Entities;
using Exam_Library.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Exam_Library.Entities.Action;

namespace Exam_Library
{

    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() {
            //this.Database.EnsureCreated();
        }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Reserved> Reserveds { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Worker> Workers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = localhost\SQLEXPRESS;
                                 Initial Catalog= LibraryDb;
                                 Integrated Security=true;
                                 Connect Timeout = 20;Encrypt=False;
                                 Trust Server Certificate=False;
                                 Application Intent=ReadWrite;
                                 Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API

            // action
            modelBuilder.Entity<Action>()
                .Property(a => a.Name)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<Action>()
                .Property(a => a.DiscountPercentage)
                .IsRequired();
            modelBuilder.Entity<Action>()
                .Property(a => a.DataStart)
                .IsRequired();
            modelBuilder.Entity<Action>()
                .Property(a => a.DataEnd)
                .IsRequired();

            // author
            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Author>()
                .Property(a => a.Lastname)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Author>()
                .Property(c => c.Country)
                .HasMaxLength(50);

            // book

            modelBuilder.Entity<Book>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Description)
                .HasMaxLength(350)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Publisher)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.NumberOfPages)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Genre)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Year)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Cost)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Price)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.IsSequel)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.HasDiscount)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Status)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(c => c.Count)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(a=>a.Rating)
                .IsRequired();

            // client
            modelBuilder.Entity<Client>()
                .Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(a => a.Surname)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(a=>a.Login)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(a => a.Password)
                .HasMaxLength(50)
                .IsRequired();

            // library
            modelBuilder.Entity<Library>()
                .Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Library>()
                .Property(a => a.Address)
                .HasMaxLength(250)
                .IsRequired();

            // reserved
            modelBuilder.Entity<Reserved>()
                .Property(a => a.Status)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Reserved>()
                .Property(a => a.DateOfReservetion)
                .IsRequired();

            // sale
            modelBuilder.Entity<Sale>()
                .Property(a => a.SaleDate)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(a => a.Quantity)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(a => a.TotalPrice)
                .IsRequired();

            // worker
            modelBuilder.Entity<Worker>()
                .Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(a => a.Surname)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(a => a.Position)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(a => a.Salary)
                .IsRequired();

            //Relationship Configuration
            // worker relationship
            modelBuilder.Entity<Worker>()
                .HasOne(a => a.Library)
                .WithMany(s => s.Workers)
                .HasForeignKey(w => w.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Worker>()
                .HasMany(a => a.Sales)
                .WithOne(w => w.Worker)
                .HasForeignKey(s => s.WorkerId).OnDelete(DeleteBehavior.Restrict);

            // library relationship
            modelBuilder.Entity<Library>()
                .HasMany(a=>a.Clients)
                .WithOne(s=>s.Library)
                .HasForeignKey(d=>d.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Library>()
                .HasMany(a=>a.Books)
                .WithOne(s=>s.Library)
                .HasForeignKey(w=>w.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Workers)
                .WithOne(w => w.Library)
                .HasForeignKey(w => w.LibraryId).OnDelete(DeleteBehavior.Restrict);

            // book relationship
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(w => w.AuthorId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasMany(a => a.Reserveds)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Clients)
                .WithMany(c => c.Books);
            modelBuilder.Entity<Book>()
                .HasMany(a => a.Sales)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasMany(a => a.Actions)
                .WithMany(a => a.Books);
            // client retaionship
            modelBuilder.Entity<Client>()
                .HasOne(a=>a.Library)
                .WithMany(a => a.Clients)
                .HasForeignKey(a=>a.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Client>()
                .HasMany(a => a.Books)
                .WithMany(a => a.Clients);
            modelBuilder.Entity<Client>()
                .HasMany(a => a.Reserved)
                .WithOne(a => a.Client)
                .HasForeignKey(c => c.ClientId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Client>()
                .HasMany(a=>a.Sales)
                .WithOne(a => a.Client) 
                .HasForeignKey(c => c.ClientId).OnDelete(DeleteBehavior.Restrict);
            // reserved relationship
            modelBuilder.Entity<Reserved>()
                .HasOne(a=>a.Client)
                .WithMany(a=>a.Reserved)
                .HasForeignKey(a=>a.ClientId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reserved>()
                .HasOne(a => a.Book)
                .WithMany(a => a.Reserveds)
                .HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            // author relationship
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Restrict);
            // action relationship
            modelBuilder.Entity<Action>()
                .HasMany(a => a.Books)
                .WithMany(a => a.Actions);
            // sale relationship
            modelBuilder.Entity<Sale>()
                .HasOne(a => a.Book)
                .WithMany(a => a.Sales)
                .HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sale>()
                .HasOne(a=>a.Worker)
                .WithMany(a => a.Sales)
                .HasForeignKey(a=>a.WorkerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sale>()
                .HasOne(a => a.Client)
                .WithMany(a => a.Sales)
                .HasForeignKey(a => a.ClientId).OnDelete(DeleteBehavior.Restrict);


            // Initializer
            modelBuilder.SeedWorkers();
            modelBuilder.SeedActions();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedBooks();
            modelBuilder.SeedClients();
            modelBuilder.SeedLibraries();
            modelBuilder.SeedReservations();
            modelBuilder.SeedSales();
        }
    }
}
