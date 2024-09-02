using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Library
{

    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = localhost\SQLEXPRESS;
                                 Initial Catalog= LibraryDb;
                                 Integrated Security=true;
                                 Connect Timeout = 2;Encrypt=False;
                                 Trust Server Certificate=False;
                                 Application Intent=ReadWrite;
                                 Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
        }
    }
}
