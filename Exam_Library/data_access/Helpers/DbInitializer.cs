using Exam_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Exam_Library.Entities.Action;

namespace Exam_Library.Helpers
{
    public static class DbInitializer
    {
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker[]
                {
                    new Worker()
                    {
                        Id = 1,
                        Name ="Sergay",
                        Surname = "Kulumyk",
                        Salary = 16000,
                        Position = "Seller",
                        LibraryId = 1
                    },
                    new Worker()
                    {
                        Id=2,
                        Name = "Olena",
                        Surname = "Kvitka",
                        Salary = 26000,
                        Position = "Manager",
                        LibraryId = 1

                    },
                    new Worker() 
                    {
                        Id = 3,
                        Name = "Ivan",
                        Surname = "Symonenko",
                        Salary = 20000,
                        Position = "Seller",
                        LibraryId = 2
                    },
                    new Worker()
                    {
                        Id = 4,
                        Name = "Petro",
                        Surname = "Vunograskiy",
                        Salary = 35000,
                        Position = "Director",
                        LibraryId = 1
                    },
                    new Worker()
                    {
                        Id = 5,
                        Name = "Sveta",
                        Surname = "Socol",
                        Salary = 28000,
                        Position = "Manager",
                        LibraryId = 2
                    },
                    new Worker()
                    {
                        Id = 6,
                        Name = "Andriy",
                        Surname = "Petlura",
                        Salary = 37000,
                        Position = "Director",
                        LibraryId = 1
                    },
                });
        }
        public static void SeedLibraries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasData(
                new Library[]
                {
                    new Library()
                    {
                        Id= 1,
                        Name = "Central city library named after V. Korolenko",
                        Address = "Kyivska street, 44, Rivne, Rivne region"
                    },
                    new Library()
                    {
                        Id= 2,
                        Name = "Rivne regional library for young people",
                        Address = "Kyivska street, 18, Rivne, Rivne region"
                    }
                });
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client[]
                {
                    new Client()
                    {
                        Id = 1,
                        Name = "Turner",
                        Surname = "Winifrede",
                        LibraryId = 1,
                    },
                    new Client()
                    {
                        Id = 2,
                        Name = "Lopez",
                        Surname = "Quintina",
                        LibraryId = 1,
                    },
                    new Client()
                    {
                        Id = 3,
                        Name = "White",
                        Surname = "Uda",
                        LibraryId = 1,
                    },
                    new Client()
                    {
                        Id = 4,
                        Name = "Sanchez",
                        Surname = "Jonah",
                        LibraryId = 1,
                    },
                    new Client()
                    {
                        Id = 5,
                        Name = "Thomas",
                        Surname = "Zachery",
                        LibraryId = 1,
                    },
                    new Client()
                    {
                        Id = 6,
                        Name = "Foster",
                        Surname = "Quartney",
                        LibraryId = 2,
                    },
                    new Client()
                    {
                        Id = 7,
                        Name = "Perez",
                        Surname = "Felipe",
                        LibraryId = 2,
                    },
                    new Client()
                    {
                        Id = 8,
                        Name = "Jackson",
                        Surname = "Isaias",
                        LibraryId = 2,
                    },
                    new Client()
                    {
                        Id = 9,
                        Name = "Garcia",
                        Surname = "Faris",
                        LibraryId = 2,
                    },
                });
        }
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book()
                    {
                        Id = 1,
                        Name = "The Foxhole Court",
                        Description = "Neil Josten is the newest addition to the Palmetto " +
                        "State University Exy team.",
                        AuthorId = 1,
                        Publisher = "Nora Sakavic",
                        NumberOfPages = 260,
                        Genre = "Young Adult",
                        Year = 2013,
                        Cost = 520,
                        Price = 570,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 10,
                        LibraryId = 1

                    },
                    new Book()
                    {
                        Id = 2,
                        Name = "The Raven King",
                        Description = "The Foxes are a fractured mess, but their latest disaster" +
                        " might be the miracle they've always needed to come together as a team. " +
                        "The one person standing in their way is Andrew, and the only one who can" +
                        " break through his personal barriers is Neil.",
                        AuthorId = 1,
                        Publisher = "Nora Sakavic",
                        NumberOfPages = 432,
                        Genre = "Contemporary literature",
                        Year = 2013,
                        Cost = 590,
                        Price = 670,
                        IsSequel = true,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 10,
                        LibraryId = 1
                    },
                    new Book() 
                    { 
                        Id = 3, 
                        Name = "The King's Men",
                        Description = "He knew when he came to PSU he wouldn't" +
                        " survive the year, but with his death right around the corner he's got more reasons" +
                        " than ever to live. ",
                        AuthorId = 1,
                        Publisher = "Nora Sakavic",
                        NumberOfPages = 448,
                        Genre = "Contemporary literature",
                        Year = 2014,
                        Cost = 640,
                        Price = 750,
                        IsSequel = true,
                        HasDiscount = false,
                        Status = "Reserved",
                        Count = 1,
                        LibraryId = 1

                    },
                    new Book()
                    {
                        Id = 4,
                        Name = "The Sunshine Court",
                        Description = "It is a truth Jean has built his life around, a reminder this is the best he can hope for and all he deserves.",
                        AuthorId = 1,
                        Publisher = "Nora Sakavic",
                        NumberOfPages = 330,
                        Genre = "Contemporary literature",
                        Year = 2024,
                        Cost = 630,
                        Price = 630,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Sold",
                        Count = 0,
                        LibraryId = 1
                    },
                    new Book()
                    { 
                        Id = 5, 
                        Name = "I see you are interested in the dark",
                        Description = "\"I see you are interested in the dark\" is a story" +
                        " about impenetrable human indifference and the darkness within us",
                        AuthorId = 2,
                        Publisher = "Old Lion Publishing House",
                        NumberOfPages = 664,
                        Genre = "Fiction",
                        Year = 2022,
                        Cost = 550,
                        Price = 550,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 15,
                        LibraryId = 1
                    },
                    new Book() 
                    { 
                        Id = 6, 
                        Name = "Starless sea",
                        Description = "Zachary Ezra Rawlins is an ordinary student living on a university campus in Vermont.",
                        AuthorId = 3, //Erin Morgenstern
                        Publisher = "Vivat",
                        NumberOfPages = 554,
                        Genre = "Adventure novel",
                        Year = 2023,
                        Cost = 230,
                        Price = 230,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 8,
                        LibraryId = 1
                    },
                    new Book() 
                    { 
                        Id = 7,
                        Name = "Konotop Witch",
                        Description = "Elena's life has finally become truly happy: the smell of delicious coffee in a cozy house, " +
                        "a beloved husband and a cute dog nearby, soon - a dream wedding...",
                        AuthorId = 4,//V. Tsybulska
                        Genre = "Mystical Horror",
                        Publisher = "KSD",
                        NumberOfPages = 272,
                        Year = 2024,
                        Cost = 250,
                        Price = 250,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 9,
                        LibraryId = 2
                    },
                    new Book() 
                    { 
                        Id = 8,
                        Name = "\"Death in Venice\" and other short stories",
                        Description = "The narrator describes his family's trip to the fictional seaside " +
                        "town of Torre di Venere, where he encounters a magician and hypnotist named Cipolla.",
                        AuthorId = 5,//Thomas Mann
                        Genre = "novel",
                        Publisher = "Laboratory",
                        NumberOfPages = 312,
                        Year = 1912,
                        Cost = 440,
                        Price = 440,
                        IsSequel = false,
                        HasDiscount = true,
                        Status = "Available",
                        Count = 10,
                        LibraryId = 2
                    },
                    new Book() 
                    { 
                        Id = 9, 
                        Name = "451° Fahrenheit",
                        Description = "Fahrenheit 451 tells the story of Guy" +
                        " Montag and his transformation from a book-burning " +
                        "fireman to a book-reading rebel. ",
                        AuthorId = 6,//Ray Bradbury
                        Publisher = "Educational book - Bohdan",
                        NumberOfPages = 272,
                        Genre = "fantasy, horror",
                        Year = 1953,
                        Cost = 200,
                        Price = 220,
                        IsSequel = false,
                        HasDiscount = false,
                        Status = "Available",
                        Count = 12,
                        LibraryId = 2

                    },
                    new Book()
                    {
                        Id = 10,
                        Name = "To kill a mockingbird",
                        Description = "Set in small-town Alabama, the novel is a bildungsroman and chronicles the childhood of" +
                        " Scout and Jem Finch as their father Atticus defends a Black man " +
                        "falsely accused of rape. ",
                        AuthorId = 7,//Harper Lee
                        Publisher = "KM-BUKS",
                        NumberOfPages = 384,
                        Genre = "Southern Gothic Bildungsroman",
                        Year = 1960,
                        Cost = 400,
                        Price = 400,
                        IsSequel = false,
                        HasDiscount = true,
                        Status = "Available",
                        Count = 20,
                        LibraryId = 2

                    },
                    new Book()
                    {
                        Id = 11,
                        Name = "Jane Eyre",
                        Description = "Jane describes herself as, \"poor, obscure, plain and little.\" " +
                        "Mr. Rochester once compliments Jane's \"hazel eyes and hazel hair\"",
                        AuthorId = 8,//Charlotte Brontë
                        Publisher = "Nebo Booklab Publishing",
                        NumberOfPages = 728,
                        Genre = "Gothic Bildungsroman Romance",
                        Year = 1847,
                        Cost = 460,
                        Price = 460,
                        IsSequel = false,
                        HasDiscount = true,
                        Status = "Available",
                        Count = 19,
                        LibraryId = 2

                    },
                    new Book()
                    {
                        Id = 12,
                        Name = "Konotop Witch",
                        Description = "The story tells about the events in the small town of Konotop",
                        AuthorId = 9,//Grigory Kvitky-Osnovyanenko
                        Publisher = "Vivat",
                        NumberOfPages = 524,
                        Genre = "Satirical story",
                        Year = 1833,
                        Cost = 390,
                        Price = 390,
                        IsSequel = false,
                        HasDiscount = true,
                        Status = "Available",
                        Count = 17,
                        LibraryId = 2

                    }

                });
        }
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                    new Author()
                    {
                        Id = 1,
                        Name = "Nora",
                        Lastname = "Sakavic",
                        Country = "USA"
                    },
                    new Author()
                    {
                        Id = 2,
                        Name = "Hilarion",
                        Lastname = "Pavlyuk",
                        Country = "Ukraine"
                    },
                    new Author()
                    {
                        Id = 3,
                        Name = "Erin",
                        Lastname = "Morgenstern",
                        Country = "USA"
                    },
                    new Author()
                    {
                        Id = 4,
                        Name = "V.",
                        Lastname = "Tsybulska",
                        Country = "Ukraine"
                    },
                    new Author()
                    {
                        Id = 5,
                        Name = "Thomas",
                        Lastname = "Mann",
                        Country = "Germany"
                    },
                    new Author()
                    {
                        Id = 6,
                        Name = "Ray",
                        Lastname = "Bradbury",
                        Country = "USA"
                    },
                    new Author()
                    {
                        Id = 7,
                        Name = "Harper",
                        Lastname = "Lee",
                        Country = "USA"
                    },
                    new Author()
                    {
                        Id = 8,
                        Name = "Charlotte",
                        Lastname = "Brontë",
                        Country = "UK"
                    },
                    new Author()
                    {
                        Id = 9,
                        Name = "Grigory",
                        Lastname = "Kvitky-Osnovyanenko",
                        Country = "Ukraine"
                    },
                });
        }
        public static void SeedActions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>().HasData(
                new Action[] 
                {
                    new Action() 
                    { 
                        Id = 1,
                        Name = "Autumn Action",
                        DataStart = DateTime.Parse( "12/08/2024"),
                        DataEnd = DateTime.Parse("12/11/2024"),
                        DiscountPercentage = 25
                    },
                    new Action() {
                        Id = 2,
                        Name = "After Summer Action",
                        DiscountPercentage= 45,
                        DataEnd = DateTime.Parse("09/10/2024"),
                        DataStart = DateTime.Parse("08/11/2024")

                    }
                }
                );
        }
        public static void SeedReservations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserved>().HasData(
                new Reserved[] {
                    new Reserved()
                    {
                        Id = 1,
                        BookId = 4,
                        ClientId = 5,
                        DateOfReservetion = DateTime.Parse("08/08/2024"),
                        Status = "Completed"
                    },
                    new Reserved()
                    {
                        Id = 2,
                        BookId = 3,
                        ClientId = 2,
                        DateOfReservetion = DateTime.Parse("03/09/2024"),
                        Status = "Active"
                    },
                    new Reserved()
                    {
                        Id = 3,
                        BookId = 7,
                        ClientId = 4,
                        DateOfReservetion = DateTime.Parse("01/02/2024"),
                        Status = "Completed"
                    },
                    new Reserved()
                    {
                        Id = 4,
                        BookId = 11,
                        ClientId = 8,
                        DateOfReservetion = DateTime.Parse("05/05/2024"),
                        Status = "Completed"
                    },
                    new Reserved()
                    {
                        Id = 5,
                        BookId = 8,
                        ClientId = 9,
                        DateOfReservetion = DateTime.Parse("08/06/2024"),
                        Status = "Completed"
                    },
                    new Reserved()
                    {
                        Id = 6,
                        BookId = 9,
                        ClientId = 1,
                        DateOfReservetion = DateTime.Parse("18/12/2023"),
                        Status = "Completed"
                    }

                });
        }
        public static void SeedSales(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData(
                new Sale[] 
                {
                    new Sale()
                    {
                        Id = 1,
                        BookId = 1,
                        WorkerId = 1,
                        ClientId = 1,
                        SaleDate = DateTime.Parse("12/12/2023"),
                        Quantity = 1,
                        TotalPrice = 570,
                    },
                    new Sale()
                    {
                        Id = 2,
                        BookId = 5,
                        WorkerId = 4,
                        ClientId = 2,
                        SaleDate = DateTime.Parse("15/08/2024"),
                        Quantity = 2,
                        TotalPrice = 1140,
                    },
                    new Sale()
                    {
                        Id = 3,
                        BookId = 4,
                        WorkerId = 5,
                        ClientId = 3,
                        SaleDate = DateTime.Parse("14/07/2024"),
                        Quantity = 1,
                        TotalPrice = 630,
                    },
                    new Sale()
                    {
                        Id = 4,
                        BookId = 12,
                        WorkerId = 1,
                        ClientId = 4,
                        SaleDate = DateTime.Parse("19/06/2024"),
                        Quantity = 3,
                        TotalPrice = 1170,
                    },
                    new Sale()
                    {
                        Id = 5,
                        BookId = 6,
                        WorkerId = 1,
                        ClientId = 5,
                        SaleDate = DateTime.Parse("15/05/2024"),
                        Quantity = 1,
                        TotalPrice = 230,
                    },
                    new Sale()
                    {
                        Id = 6,
                        BookId = 9,
                        WorkerId = 1,
                        ClientId = 6,
                        SaleDate = DateTime.Parse("13/02/2024"),
                        Quantity = 1,
                        TotalPrice = 220,
                    },
                    new Sale()
                    {
                        Id = 7,
                        BookId = 8,
                        WorkerId = 1,
                        ClientId = 7,
                        SaleDate = DateTime.Parse("25/01/2024"),
                        Quantity = 2,
                        TotalPrice = 880,
                    },

                });
        }
    }
}
