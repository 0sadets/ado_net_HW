using Exam_Library;
using Exam_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Threading.Channels;
using static System.Collections.Specialized.BitVector32;
using Action = Exam_Library.Entities.Action;

namespace ShopDB
{
    internal class Program
    {
        // Packages:
        // Microsoft.EntityFrameworkCore
        // Microsoft.EntityFrameworkCore.SqlServer 
        // Microsoft.EntityFrameworkCore.Tools - for migrations

        // for migrations: Tools ->
        // NuGet Package Manager ->
        // Package Manager Console -> 
        // *add-migration [name]*
        // update-database

        //Основне завдання проєкту — враховувати поточний асортимент книг в магазині.
        //Необхідно зберігати наступну інформацію про книги: назва книги, ПІБ автора,
        //назва видавництва, кількість сторінок, жанр, рік видання, собівартість, ціна для
        //продажу, чи є книга продовженням якоїсь іншої книги (наприклад, друга частина
        //дилогії).

        //Додаток має дозволяти: додавати книги, видаляти книги, редагувати параметри
        //книг, продавати книги, списувати книги, вносити книги в акції(наприклад, тиждень книг новорічної тематики зі знижкою 10%), відкласти книги для конкретного покупця.
        //Додаток має надати функціональність пошуку книг за такими параметрами: назва книги, автор, жанр. Додаток має надавати можливість переглядати список
        //новинок, список найпопулярніших книг, список найпопулярніших авторів
        //Необхідно передбачити можливість входу за логіном і паролем.

        // admin:  додавати книги, видаляти книги, редагувати параметри книг, продавати книги,
        // списувати книги, вносити книги в акції, відкласти книги для конкретного покупця.
        static void Login(LibraryDbContext context)
        {
            try
            {
                Console.Write("1. Client" +
                        "\n2. Admin" +
                        "\n3. Create Account " +
                        "\n4. Leave" +
                        "\na: ");
                int us = Convert.ToInt32(Console.ReadLine());

                if (us == 1)
                {
                    Console.Write("Please, login to your account:\nUsername: ");
                    string usname = Console.ReadLine();
                    Console.Write("\nPassword: ");
                    string psw = Console.ReadLine();

                    var client = context.Clients.FirstOrDefault(c => c.Login == usname && c.Password == psw);
                    if (client != null)
                    {
                        Console.WriteLine($"Welcome, {client.Name} {client.Surname}!");
                        ClientMenu(context, client);
                    }
                    else { Console.WriteLine("No such user exists. Try again"); Login(context); }
                }
                else if (us == 2)
                {
                    Console.Write("Please, login to your account:\nUsername: ");
                    string usname = Console.ReadLine();
                    Console.Write("\nPassword: ");
                    string psw = Console.ReadLine();

                    var worker = context.Workers.FirstOrDefault(w => w.Login == usname && w.Password == psw);
                    if (worker != null)
                    {
                        Console.WriteLine($"Welcome, {worker.Name} {worker.Surname}!");
                        AdminMenu(context, worker);
                    }
                    else { Console.WriteLine("No such user exists. Try again"); Login(context); }
                }
                else if (us == 4)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Choise. Try Again");
                    Login(context);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
        static void AdminMenu(LibraryDbContext context, Worker worker) 
        {
            Console.Write("Select Option:\n" +
                              "1. Add Book\n" +
                              "2. Delete Book\n" +
                              "3. Update Book\n" +
                              "4. Sell Book\n" +
                              "5. Write off Book\n" +
                              "6. Add Book to Action\n" +
                              "7. Reserv Book\n" +
                              "8. Exit\n" +
                              "a: ");
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1: AddBook(context, worker); break;
                case 2: DeleteBook(context, worker); break;
                case 3: UpdateBook(context, worker); break;
                case 4: SellBook(context, worker); break;
                case 5: WritteOffBook(context, worker); break;
                case 6: AddToAction(context, worker); break;
                case 7: ReservBook(context, worker); break;
                case 8: return; 

                    default: Console.WriteLine("Error. Try Again.");AdminMenu(context, worker); break;
            }

        }
        static void ReservBook(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Reserv Book ---");
                Console.WriteLine("Select Book.");
                var book = GetBook(context, worker);
                if (book == null)
                {
                    Console.WriteLine("There is no such Book.");
                    AdminMenu(context, worker);
                }
                if (book.Status == "sold" || book.Count == 0)
                {
                    Console.WriteLine("The book is not available for reservation.");
                    AdminMenu(context, worker);
                    return;
                }

                Console.WriteLine("Select Client.");
                var client = GetClient(context);
                while(client == null)
                {
                    string answ;
                    do
                    {
                        Console.WriteLine("There is no such Client. Do you want to add Client?(yes/no)\na: ");
                        answ = Console.ReadLine().ToLower();
                        if (answ == "yes")
                        {
                            client = AddClient(context, worker.LibraryId);
                        }
                        else if (answ == "no")
                        {
                            AdminMenu(context, worker); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    } while (answ != "yes" && answ != "no");

                }
                DateTime reserv_date = DateTime.Now;
                string status = "active";
                var reserv = new Reserved()
                {
                    BookId = book.Id,
                    ClientId = client.Id,
                    DateOfReservetion = reserv_date,
                    Status = status,
                };
                context.Reserveds.Add( reserv );
                book.Status = "reserved";
                context.SaveChanges();
                Console.WriteLine($"Book '{book.Name}' has been successfully reserved by {client.Name} {client.Surname}.");
                AdminMenu(context, worker);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void AddToAction(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Add Book To Action ---");

                Console.WriteLine("Select Book.");
                var book = GetBook(context, worker);
                if (book == null)
                {
                    Console.WriteLine("There is no such Book.");
                    AdminMenu(context, worker);
                }


                Console.WriteLine("Select Action. ");
                Console.Write("Enter Action Name: ");
                string actionName = Console.ReadLine();
                var action = context.Actions.FirstOrDefault(a=> a.Name == actionName);

                if (action == null) {
                    string answ;
                    do
                    {
                        Console.WriteLine("There is no such action. Do you want to create action?(yes/no)\na:");
                        answ = Console.ReadLine().ToLower();
                        if (answ == "yes")
                        {
                            action = AddAction(context, worker, actionName);
                        }
                        else if(answ == "no")
                        {
                            AdminMenu(context, worker); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != "yes" && answ != "no");

                }
                if (action.Books.Contains(book))
                {
                    Console.WriteLine("The book is already in the selected action.");
                }
                else
                {
                    action.Books.Add(book);

                    context.SaveChanges();
                    Console.WriteLine("Book successfully added to the action.");
                }

                AdminMenu(context, worker);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static Action AddAction(LibraryDbContext context, Worker worker, string name)
        {
            try
            {
                Console.WriteLine("--- Add Action ---");

                Console.Write("Enter the start date(YYYY-MM-DD): ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter the end date(YYYY-MM-DD): ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Discount Perscentage: ");
                float disc = float.Parse(Console.ReadLine());

                var action = new Action
                {
                    Name = name,
                    DataStart = start,
                    DataEnd = end,
                    DiscountPercentage = disc
                };
                context.Actions.Add(action);
                context.SaveChanges();
                Console.WriteLine("Action successfully added.");
                return action;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }

        }
        static void WritteOffBook(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Write Off Book ---");
                var book = GetBook(context, worker);
                if (book != null) {
                    book.Count = 0;
                    context.Books.Update(book);
                    context.SaveChanges();
                    Console.WriteLine("The Book is Written Off.");
                }
                else
                {
                    Console.WriteLine("There is no such book.");
                }
                AdminMenu(context, worker);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void SellBook(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Sell Book ---");
                var book = GetBook(context, worker);
                if (book != null)
                {
                    book = context.Books
                        .Include(b => b.Author)  
                        .Include(b => b.Actions) 
                        .FirstOrDefault(b => b.Id == book.Id);
                }
                if (book == null) {
                    Console.WriteLine("There is no such Book.");
                    AdminMenu(context, worker);
                    return;
                }

                int libraryid = worker.LibraryId;

                var client = GetClient(context);
                while (client == null) {
                    string answ;
                    do
                    {
                        Console.WriteLine("There is no such Client. Do you want to add Client?(yes/no)\na: ");
                        answ = Console.ReadLine().ToLower();
                        if (answ == "yes")
                        {
                            client = AddClient(context, libraryid);
                        }
                        else if (answ == "no")
                        {
                            AdminMenu(context, worker); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != "yes" && answ != "no");
                }
                int quantity;
                do
                {
                    Console.Write("Enter Quantity: ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    if (quantity > book.Count)
                    {
                        Console.WriteLine($"There is only {book.Count} items left. ");
                    }
                } while (quantity > book.Count);
                decimal totalPrice;
                float discountPercentage = 0;
                if (book.HasDiscount)
                {
                    var activeAction = book.Actions.FirstOrDefault(a => a.DataStart <= DateTime.Now && a.DataEnd >= DateTime.Now);

                    if (activeAction != null)
                    {
                        discountPercentage = activeAction.DiscountPercentage;
                        Console.WriteLine($"Discount applied: {discountPercentage}%");
                    }
                }
                decimal finalPricePerBook = book.Price;
                if (discountPercentage > 0)
                {
                    finalPricePerBook = book.Price - (book.Price * (decimal)(discountPercentage / 100));
                }

                totalPrice = finalPricePerBook * quantity;

                var sell = new Sale()
                {
                    BookId = book.Id,
                    ClientId = client.Id,
                    WorkerId = worker.Id,
                    SaleDate = DateTime.Now,
                    Quantity = quantity,
                    TotalPrice = totalPrice,
                };
                context.Sales.Add(sell);
                book.Count = book.Count - quantity;
                context.SaveChanges();
                Console.WriteLine("Book(s) was successfully sold.");
                Console.WriteLine($"Book: {book.Name}");
                Console.WriteLine($"Author: {book.Author.Name} {book.Author.Lastname}");
                Console.WriteLine($"Seller: {worker.Name} {worker.Surname}");
                Console.WriteLine($"Recipient: {client.Name} {client.Surname}");
                Console.WriteLine($"Count: {quantity}");
                Console.WriteLine($"Total Price: {totalPrice}");
                Console.WriteLine("----------------------------------------------------");
                AdminMenu(context, worker);
                

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static Client GetClient(LibraryDbContext context)
        {
            try
            {
                Console.Write("Enter Client`s Name: ");
                string client_name = Console.ReadLine();

                Console.Write("Enter Client`s Surname: ");
                string client_surname = Console.ReadLine();

                var client = context.Clients.FirstOrDefault(a => a.Name == client_name && a.Surname == client_surname);
                return client;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }

        }
        static Client AddClient(LibraryDbContext context, int libraryid)
        {
            try
            {
                Console.WriteLine("--- Add Client ---");
                Console.Write("Enter new Clients Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter new Clients Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Enter new Clients Login: ");
                string login = Console.ReadLine();

                Console.Write("Enter new Clients Password: ");
                string psw = Console.ReadLine();

                var client = new Client()
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Password = psw,
                    LibraryId = libraryid
                };
                context.Clients.Add(client);
                context.SaveChanges();
                Console.WriteLine("Client successfully added!");
                return client;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }
        static void UpdateBook(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Update Book ---");
                var book = GetBook(context, worker);
                if(book == null)
                {
                    Console.WriteLine("There is no such book.");
                    AdminMenu(context, worker);
                }
                int answ;
                while(true)
                {
                    Console.WriteLine("Enter Update Option: \n" +
                                    "0. Exit\n" +
                                    "1. Name\n" +
                                    "2. Description\n" +
                                    "3. Author\n" +
                                    "4. Publisher\n" +
                                    "5. Number Of Pages\n" +
                                    "6. Genre\n" +
                                    "7. Year\n" +
                                    "8. Cost\n" +
                                    "9. Price\n" +
                                    "10. Is Sequal\n" +
                                    "11. Has Discount\n" +
                                    "12. Status\n" +
                                    "13. Count\n" +
                                    "14. Rating\na:");
                    answ = Convert.ToInt32(Console.ReadLine());
                    switch (answ) {
                        case 0:
                            Console.WriteLine("Returning to Admin Menu...");
                            AdminMenu(context, worker); 
                            return; 
                        case 1: 
                            Console.Write("Enter new Name: ");
                            book.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter new Description: ");
                            book.Description = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter new Authors Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter new Authors Lastname: ");
                            string lastname = Console.ReadLine();
                            var author = context.Authors.FirstOrDefault(a => a.Name == name && a.Lastname == lastname);
                            if (author == null)
                            {
                                author = AddAuthor(context, name, lastname, worker);
                            }
                            book.AuthorId = author.Id;
                            break;
                        case 4:
                            Console.Write("Enter new Publisher: ");
                            book.Publisher = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Enter new Number of Pages: ");
                            book.NumberOfPages = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            Console.Write("Enter new Genre: ");
                            book.Genre = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write("Enter new Publish Year: ");
                            book.Year = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.Write("Enter new Cost: ");
                            book.Cost = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 9:
                            Console.Write("Enter new Price: ");
                            book.Price = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 10:
                            Console.Write("Is book sequal?(yes/no): ");
                            string seq_answ = Console.ReadLine().ToLower();
                            if(seq_answ == "yes")
                            {
                                book.IsSequel = true;
                            }
                            else if (seq_answ == "no")
                            {
                                book.IsSequel= false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid answer.");
                                break;
                            }
                            break;
                        case 11:
                            Console.Write("Does book have discount?(yes/no): ");
                            string dis_answ = Console.ReadLine().ToLower();
                            if (dis_answ == "yes")
                            {
                                book.HasDiscount = true;
                            }
                            else if (dis_answ == "no")
                            {
                                book.HasDiscount = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid answer.");
                                break;
                            }
                            break;
                        case 12:
                            string status;
                            do
                            {
                                Console.Write("Enter new Book Status (available/sold/reserved): ");
                                status = Console.ReadLine().ToLower();
                            }
                            while (status != "available" && status != "sold" && status != "reserved");
                            break;
                        case 13:
                            Console.Write("Enter new Count: ");
                            book.Count = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 14:
                            int rating;
                            do
                            {
                                Console.Write("Enter new Rating(1-10): ");
                                rating = Convert.ToInt32(Console.ReadLine());
                            }
                            while (rating < 0 && rating > 10);
                            break;
                        default: Console.WriteLine("Invalid Option."); break;

                    }
                    context.Books.Update(book);
                    context.SaveChanges();

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static Book GetBook(LibraryDbContext context, Worker worker)
        {
            Console.Write("Enter Book Name: ");
            string bookName = Console.ReadLine();

            Console.Write("Enter Author's Name: ");
            string authorName = Console.ReadLine();

            Console.Write("Enter Author's Lastname: ");
            string authorLastname = Console.ReadLine();

            var book = context.Books
                .FirstOrDefault(b => b.Name == bookName && b.Author.Name == authorName && b.Author.Lastname == authorLastname);
            return book;
        }
        static void DeleteBook(LibraryDbContext context, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Delete Book ---");
                
                var book = GetBook(context, worker);

                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine($"Book '{book.Name}' by {book.Author.Name} {book.Author.Lastname} has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Book '{book.Name}' by {book.Author.Name} {book.Author.Lastname} was not found.");
                    AdminMenu(context, worker);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void AddBook(LibraryDbContext context, Worker worker)
        {
            Console.WriteLine("--- Add Book--- ");
            try
            {
                // name
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                // desc
                Console.Write("Enter Description: ");
                string desc = Console.ReadLine();
                // author
                Console.Write("Enter Author Name: ");
                string aname = Console.ReadLine();

                Console.Write("Enter Author Lastname: ");
                string alastname = Console.ReadLine();

                var author = context.Authors.FirstOrDefault(a => a.Name == aname && a.Lastname == alastname);
                if (author == null)
                {
                    string answ;
                    do
                    {
                        Console.WriteLine("This Author does not exist in db. Do you want to update db?(yes/no):  ");
                        answ = Console.ReadLine().ToLower();
                        if (answ == "yes")
                        {
                            author = AddAuthor(context, aname, alastname, worker);
                        }
                        else if (answ == "no")
                        {
                            Console.WriteLine("You can NOT add book without an Author.");
                            AdminMenu(context, worker);
                        }
                        else Console.WriteLine("Invalid answer.");
                    } while (answ != "yes" && answ != "no");
                    
                }

                int authorId = author.Id;
                

                // publisher
                Console.Write("Enter Publisher name: ");
                string publisher = Console.ReadLine();
                // numberOfPages
                Console.Write("Enter Number of Pages: ");
                int pages = Convert.ToInt32(Console.ReadLine());
                // genre
                Console.Write("Enter Genre: ");
                string genre = Console.ReadLine();
                // year
                Console.Write("Enter Year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                // cost
                Console.Write("Enter Cost: ");
                decimal cost = Convert.ToDecimal(Console.ReadLine());
                // price
                Console.Write("Enter Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                // sequal
                bool issequal = false;
                string seq_answ;
                do
                {
                    Console.Write("Is Book is the sequel?(yes/no): ");
                    seq_answ = Console.ReadLine().ToLower();

                    if (seq_answ == "yes") issequal = true;
                    else if (seq_answ == "no") issequal = false;
                    else Console.WriteLine("Invalid answer. ");
                } 
                while(seq_answ!="yes" && seq_answ!="no");
                // discount
                bool hasdisc = false;
                string disc_answ;
                do
                {
                    Console.Write("Does book have discount?(yes/no): ");
                    disc_answ = Console.ReadLine().ToLower();

                    if(disc_answ == "yes") hasdisc = true;
                    else if(disc_answ == "no") hasdisc = false;
                    else Console.WriteLine("Invalid answer.");
                } 
                while(disc_answ!="yes" && disc_answ!="no");
                // status
                string status;
                do
                {
                    Console.Write("Enter Book Status (available/sold/reserved): ");
                    status = Console.ReadLine().ToLower();
                }
                while (status!= "available" && status!= "sold" && status!="reserved");
                // count
                int count;
                if(status=="sold") count = 0;
                else
                {
                    Console.Write("Enter Count: ");
                    count = Convert.ToInt32(Console.ReadLine());
                }
                // rating
                int rating;
                do
                {
                    Console.Write("Enter Rating(1-10): ");
                    rating = Convert.ToInt32(Console.ReadLine());
                }
                while (rating < 0 && rating > 10);
                // Library
                int libraryId = worker.LibraryId;
                // book
                var book = new Book()
                {
                    Name = name,
                    Description = desc,
                    AuthorId = authorId,
                    Publisher = publisher,
                    NumberOfPages = pages,
                    Genre = genre,
                    Year = year,
                    Cost = cost,
                    Price = price,
                    IsSequel = issequal,
                    HasDiscount = hasdisc,
                    Status = status,
                    Count = count,
                    Rating = rating,
                    LibraryId = libraryId
                };
                context.Books.Add(book);
                context.SaveChanges();
                Console.WriteLine("Book successfully added!");
                AdminMenu(context, worker);


            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); AdminMenu(context, worker);
            }

        }
        static Author AddAuthor(LibraryDbContext context, string name, string lastname, Worker worker)
        {
            try
            {
                Console.WriteLine("--- Add Author ---");
                Console.Write("Enter Country: ");
                string country = Console.ReadLine();

                Console.Write("Enter Rating: ");
                int rating = Convert.ToInt32(Console.ReadLine());

                var author = new Author { 
                    Name = name,
                    Lastname = lastname,
                    Rating = rating,
                    Country = country
                };
                context.Authors.Add(author);
                context.SaveChanges();
                Console.WriteLine("--- Author Added ---");
                return author;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); AdminMenu(context, worker); return null; }
        }
        static void ClientMenu(LibraryDbContext context, Client client) 
        {
            try
            {
                Console.Write("Select Option: \n" +
                              "1. Search By Name\n" +
                              "2. Search By Author\n" +
                              "3. Search By Genre\n" +
                              "4. View News\n" +
                              "5. View Bestsellers\n" +
                              "6. View Best Authors\n" +
                              "7. View Actions\n" +
                              "8. Exit\n" +
                              "a:");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1: GetBookByName(context, client); break;
                    case 2: GetBooksByAuthor(context, client); break;
                    case 3: GetBooksByGenre(context, client); break;
                    case 4: GetBooksByDate(context, client); break;
                    case 5: GetBooksByRating(context, client); break;
                    case 6: GetTopAuthors(context, client); break;
                    case 7: GetActionsWithBooks(context, client); break;
                    case 8: return;

                    default: Console.WriteLine("Error. Try Again."); ClientMenu(context, client); break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        static void GetActionsWithBooks(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- View All Action Offers ---");

                var actions = context.Actions
                    .Include(a => a.Books) 
                    .OrderByDescending(a => a.DataStart) 
                    .ToList();

                if (actions.Any())
                {
                    foreach (var action in actions)
                    {
                        Console.WriteLine($"Action: {action.Name}");
                        Console.WriteLine($"Start Date: {action.DataStart}");
                        Console.WriteLine($"End Date: {action.DataEnd}");
                        Console.WriteLine($"Discount Percentage: {action.DiscountPercentage}%");

                        if (action.Books.Any())
                        {
                            Console.WriteLine("Books in this Action:");
                            foreach (var book in action.Books)
                            {
                                Console.WriteLine($" - {book.Name}, Author: {book.Author.Name} {book.Author.Lastname}, Price: {book.Price}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books in this action.");
                        }
                        Console.WriteLine("----------------------------------------------------");
                    }
                    ClientMenu(context, client); 
                }
                else
                {
                    Console.WriteLine("No actions found.");
                    ClientMenu(context, client); 
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GetTopAuthors(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- View Top Authors By Rating ---");

                var authors = context.Authors
                    .OrderByDescending(a => a.Rating) 
                    .ToList();

                if (authors.Any())
                {
                    Console.WriteLine($"Found {authors.Count} authors:");
                    int i = 1;
                    foreach (var author in authors)
                    {
                        Console.WriteLine($" {i}. {author.Name} {author.Lastname}, Rating: {author.Rating}");
                        i++;
                    }
                    ClientMenu(context, client); 
                }
                else
                {
                    Console.WriteLine("No authors found.");
                    ClientMenu(context, client); 
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GetBooksByRating(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- View Books By Rating ---");

                var books = context.Books
                    .OrderByDescending(b => b.Rating) 
                    .Include(b => b.Author)
                    .ToList();

                if (books.Any())
                {
                    Console.WriteLine($"Found {books.Count} books:");
                    int i = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine($" {i}. {book.Name}, Author: {book.Author.Name} {book.Author.Lastname}, Rating: {book.Rating}, Price: {book.Price}");
                        i++;
                    }
                    int answ;
                    do
                    {
                        Console.Write("Select Book For More Information (0-leave): ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        if (answ > 0 && answ <= books.Count)
                        {
                            DisplayBookDetails(books[answ - 1]);
                            ClientMenu(context, client); return;
                        }
                        else if (answ == 0)
                        {
                            ClientMenu(context, client); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != 0 && answ <= books.Count);
                    ClientMenu(context, client);
                }
                else
                {
                    Console.WriteLine("No books found.");
                    ClientMenu(context, client);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GetBooksByDate(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- View Books By Date ---");

                var books = context.Books
                    .OrderByDescending(b => b.Year) 
                    .Include(b => b.Author)
                    .ToList();

                if (books.Any())
                {
                    Console.WriteLine($"Found {books.Count} books:");
                    int i = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine($" {i}. {book.Name}, Author: {book.Author.Name} {book.Author.Lastname}, Year: {book.Year}, Price: {book.Price}");
                        i++;
                    }
                    int answ;
                    do
                    {
                        Console.Write("Select Book For More Information (0-leave): ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        if (answ > 0 && answ <= books.Count)
                        {
                            DisplayBookDetails(books[answ - 1]);
                            ClientMenu(context, client); return;
                        }
                        else if (answ == 0)
                        {
                            ClientMenu(context, client); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != 0 && answ <= books.Count);
                    ClientMenu(context, client);
                }
                else
                {
                    Console.WriteLine("No books found.");
                    ClientMenu(context, client);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GetBooksByGenre(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- Search Books By Genre ---");
                Console.Write("Enter Genre: ");
                string genre = Console.ReadLine();
                var books = context.Books
                    .Where(b => b.Genre.Contains(genre))
                    .Include(b => b.Author)
                    .ToList();

                if (books.Any())
                {
                    Console.WriteLine($"Found {books.Count} book(s) in genre '{genre}':");
                    int i = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine($" {i}. {book.Name}, Author: {book.Author.Name} {book.Author.Lastname}, Price: {book.Price}");
                        i++;
                    }
                    int answ;
                    do
                    {
                        Console.Write("Select Book For More Information (0-leave): ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        if (answ > 0 && answ <= books.Count)
                        {
                            DisplayBookDetails(books[answ - 1]);
                            ClientMenu(context, client); return;
                        }
                        else if (answ == 0)
                        {
                            ClientMenu(context, client); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != 0 && answ <= books.Count);
                    ClientMenu(context, client);
                }
                else
                {
                    Console.WriteLine($"No books found in genre '{genre}'.");
                    ClientMenu(context, client);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GetBooksByAuthor(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- Search Books By Author ---");

                Console.Write("Enter Author's Name: ");
                string authorName = Console.ReadLine();

                Console.Write("Enter Author's Lastname: ");
                string authorLastname = Console.ReadLine();

                var books = context.Books
                    .Where(b => b.Author.Name.Contains(authorName) && b.Author.Lastname.Contains(authorLastname))
                    .Include(b => b.Author)
                    .ToList();

                if (books.Any())
                {
                    Console.WriteLine($"Found {books.Count} book(s) by {authorName} {authorLastname}:");
                    int i = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine($" {i}. {book.Name}, Price: {book.Price}");
                        i++;
                    }
                    int answ;
                    do
                    {
                        Console.Write("Select Book For More Information (0-leave): ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        if (answ > 0 && answ <= books.Count)
                        {
                            DisplayBookDetails(books[answ - 1]);
                            ClientMenu(context, client); return;
                        }
                        else if (answ == 0)
                        {
                            ClientMenu(context, client); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while (answ != 0 && answ <= books.Count);
                    ClientMenu(context, client);
                }
                else
                {
                    Console.WriteLine($"There are no books found by {authorName} {authorLastname}.");
                    ClientMenu(context, client);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void GetBookByName(LibraryDbContext context, Client client)
        {
            try
            {
                Console.WriteLine("--- Search Book By Name ---");
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                var books = context.Books
                    .Where(b => b.Name.Contains(name)) 
                    .Include(b => b.Author) 
                    .ToList();

                if (books.Any())
                {
                    Console.WriteLine($"Found {books.Count} book(s) matching '{name}':");
                    int i = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine($" {i}. {book.Name}, Author: {book.Author.Name} {book.Author.Lastname}, Price: {book.Price}");
                        i++;
                    }
                    int answ;
                    do
                    {
                        Console.Write("Select Book For More Information(0-leave): ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        if (answ > 0 && answ <= books.Count)
                        {
                            DisplayBookDetails(books[answ - 1]);
                            ClientMenu(context, client); return;
                        }
                        else if(answ == 0)
                        {
                            ClientMenu(context, client); return;
                        }
                        else Console.WriteLine("Invalid answer.");
                    }
                    while(answ != 0 && answ <= books.Count);
                    ClientMenu(context, client);

                }
                else
                {
                    Console.WriteLine($"There is no {name} books found.");
                    ClientMenu(context, client);
                    return;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void DisplayBookDetails(Book book)
        {
            Console.WriteLine("\t=== Book Details ===");
            Console.WriteLine($"{"Field",-15} {"Value",15}");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"\n{"Name",-15} {book.Name,15}");
            Console.WriteLine($"{"Author",-15} {book.Author.Name,7} {book.Author.Lastname,7}");
           // Console.WriteLine($"{"Description",-15} {book.Description,15}");
            Console.WriteLine($"{"Publisher",-15} {book.Publisher,15}");
            Console.WriteLine($"{"Year",-15} {book.Year,15}");
            Console.WriteLine($"{"Genre",-15} {book.Genre,15}");
            Console.WriteLine($"{"Price",-15} {book.Price,15}"); 
            Console.WriteLine($"{"Cost",-15} {book.Cost,15}");
            Console.WriteLine($"{"Pages",-15} {book.NumberOfPages,15}");
            Console.WriteLine($"{"Rating",-15} {book.Rating,15}");
            Console.WriteLine($"{"Count in stock",-15} {book.Count,15}");
            Console.WriteLine($"{"Status",-15} {book.Status,15}");
            Console.WriteLine($"{"Has Discount",-15} {(book.HasDiscount ? "Yes" : "No"),15}");
            Console.WriteLine("\n=== End of Details ===");
        }

        static void Main(string[] args)
        {

            try
            {
                LibraryDbContext context = new LibraryDbContext();
                Login(context);
                
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}