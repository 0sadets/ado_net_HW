using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace HW1_Intro_Sales
{
    class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Name: {Name,-15} Type: {Type,-15} Quantity: {Quantity,-15} " +
                $"CostPrice: {CostPrice,-15} Producer: {Producer,-15} Price: {Price, -15}";
        }
    }
    class Employees
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender {  get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"FullName: {FullName,-30} Gender: {Gender,-15} HireDate: {HireDate, -20} Salary: {Salary,-15}";
        }
    }
    class Clients
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int PercentSale { get; set; }
        public bool Subscribe { get; set; }
        public override string ToString()
        {
            return $"Full Name: {FullName,-30} Gender: {Gender,-15} Phone: {Phone,-15} PercentSale: {PercentSale,-15}";
        }
    }
    class Salles
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price {  get; set; }
        public int Quantity { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public override string ToString()
        {
            return $"ProductId: {ProductId,-15} Price: {Price,-15} Quantity: {Quantity,-15} Date: {SaleDate,-15}";
        }



    }
    class SportShopDB
    {
        private SqlConnection connection;
        private string connectionString;
        public SportShopDB()
        {
            connectionString = @"Data Source = localhost\SQLEXPRESS;
                                 Initial Catalog= SportShopp;
                                 Integrated Security=true;
                                 Connect Timeout = 2;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public List<Employees> GetAllEmployees()
        {
            string cmdText = @"select * from Employeess";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                employees.Add(new Employees()
                {
                    Id = (int)reader[0],
                    FullName = (string)reader[1],
                    HireDate = (DateTime)reader[2],
                    Gender = (string)reader[3],
                    Salary = (decimal)reader[4]
                });
            }
            reader.Close();
            return employees;
        }
        public List<Clients> GetAllClients()
        {
            string cmdText = @"select * from Clients";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Clients> clients = new List<Clients>();
            while (reader.Read())
            {
                clients.Add(new Clients()
                {
                    Id = (int)reader[0],
                    FullName = (string)(reader[1]),
                    Email = (string)(reader[2]),
                    Phone = (string)reader[3],
                    Gender = (string)reader[4],
                    PercentSale = (int)reader[5],
                    Subscribe = (bool)reader[6]

                });
            }
            reader.Close();
            return clients;
        }

        public List<Salles> GetSallesByEmployee(string name)
        {
            string cmdGetEmployee = "select Id from Employeess where FullName = @EmployeeName";
            SqlCommand empCommand = new SqlCommand(cmdGetEmployee, connection);

            empCommand.Parameters.AddWithValue("@EmployeeName", name); // ai:)

            SqlDataReader sqlDataReader = empCommand.ExecuteReader();
            int employeeId;
            if (sqlDataReader.Read())
            {
                employeeId = (int)sqlDataReader["Id"];
            }
            else
            {
                throw new Exception("Employee not found.");
            }
            sqlDataReader.Close();



            string cmdText = $@"select * from Salles where EmployeeId = @EmployeeId";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;
            List<Salles> salles = new List<Salles>();
            while (reader.Read())
            {
                salles.Add(new Salles()
                {
                    Id = (int)reader[0],
                    ProductId = (int)reader[1],
                    Price = (decimal)reader[2],
                    Quantity = (int)reader[3],
                    EmployeeId = (int)reader[4],
                    ClientId = (int)reader[5],
                    SaleDate = (DateTime)reader[6]
                });
            }
            reader.Close();
            return salles;

        }
        public List<Salles> GetSallesByPrice(decimal pr)
        {
            string cmdText = $@"select * from Salles where Price > {pr}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;
            List<Salles> salles = new List<Salles>();
            while (reader.Read())
            {
                salles.Add(new Salles()
                {
                    Id = (int)reader[0],
                    ProductId = (int)reader[1],
                    Price = (decimal)reader[2],
                    Quantity = (int)reader[3],
                    EmployeeId = (int)reader[4],
                    ClientId = (int)reader[5],
                    SaleDate = (DateTime)reader[6]
                });
            }
            reader.Close();
            return salles;
        }
        public List<Salles> GetMinMaxSalles(string name)
        {
            string cmdGetEmployee = $"select * from Clientss where FullName = @ClientName";
            SqlCommand empCommand = new SqlCommand(cmdGetEmployee, connection);

            empCommand.Parameters.AddWithValue("@ClientName", name); 

            SqlDataReader sqlDataReader = empCommand.ExecuteReader();
            Employees client = new Employees();

            if (sqlDataReader.Read())
            {
                client.Id = (int)sqlDataReader["Id"];
            }
            sqlDataReader.Close();

            string cmdMax = $@"Select * from Salles 
                               Where ClientId = {client.Id}
                               and Price = (
                               Select Max(Price) from Salles
                               Where ClientId = {client.Id})";
            SqlCommand commandMax = new SqlCommand(cmdMax, connection);
            SqlDataReader readerMax = commandMax.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;
            List<Salles> salles = new List<Salles>();
            while (readerMax.Read())
            {
                salles.Add(new Salles()
                {
                    Id = (int)readerMax[0],
                    ProductId = (int)readerMax[1],
                    Price = (decimal)readerMax[2],
                    Quantity = (int)readerMax[3],
                    EmployeeId = (int)readerMax[4],
                    ClientId = (int)readerMax[5],
                    SaleDate = (DateTime)readerMax[6]
                });
            }
            readerMax.Close();
            string cmdMin = $@"Select * from Salles 
                               Where ClientId = {client.Id}
                               and Price = (
                               Select Min(Price) from Salles
                               Where ClientId = {client.Id})";
            SqlCommand commandMin = new SqlCommand(cmdMin, connection);
            SqlDataReader readerMin = commandMin.ExecuteReader();
            while (readerMin.Read())
            {
                salles.Add(new Salles()
                {
                    Id = (int)readerMin[0],
                    ProductId = (int)readerMin[1],
                    Price = (decimal)readerMin[2],
                    Quantity = (int)readerMin[3],
                    EmployeeId = (int)readerMin[4],
                    ClientId = (int)readerMin[5],
                    SaleDate = (DateTime)readerMin[6]
                });
            }
            
            readerMin.Close();
            return salles;
        }
        public Salles GetFirstByDate(string name)
        {
            string cmdGetEmployee = $"select * from Employeess where FullName = @EmployeeName";
            SqlCommand empCommand = new SqlCommand(cmdGetEmployee, connection);

            empCommand.Parameters.AddWithValue("@EmployeeName", name); // ai:)

            SqlDataReader sqlDataReader = empCommand.ExecuteReader();
            Employees employee = new Employees();

            if (sqlDataReader.Read())
            {
                employee.Id = (int)sqlDataReader["Id"];
            }
            sqlDataReader.Close();

            string cmd = @$"Select * From Salles
                           Where ClientId = {employee.Id}
                           And SaleDate = (
                           Select Min(Saledate) from Salles
                           Where EmployeeId = {employee.Id})";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();
            Salles sale = new Salles();
            Console.OutputEncoding = Encoding.UTF8;

            if(reader.Read())
            {
                sale.Id = (int)reader[0];
                sale.ProductId = (int)reader[1];
                sale.Price = (decimal)reader[2];
                sale.Quantity = (int)reader[3];
                sale.EmployeeId = (int)reader[4];
                sale.ClientId = (int)reader[5];
                sale.SaleDate = (DateTime)reader[6];
            }
            reader.Close();
            return sale;
        }
    }

    internal class Program
    {
        static void ClearConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); 
        }
        static int Menu()
        {
            Console.Write("1. Show all Clients\n" +
                              "2. Show all Employees\n" +
                              "3. Display information about sales made by a certain seller\n" +
                              "4. Display information about sales for an amount greater than the specified amount\n" +
                              "5. Display the most expensive and cheapest purchase of a certain Client\n" +
                              "6. Show the first sale of a certain seller\n" +
                              "7. Exit\n\n" +
                              "Enter Your Choise: ");
            int answ = Convert.ToInt32(Console.ReadLine());
            return answ;
        }
        static void Main(string[] args)
        {

            try
            {
                SportShopDB db = new SportShopDB();

                while (true)
                {
                    int answ = Menu();
                    switch (answ)
                    {
                        case 1:
                            var employees = db.GetAllEmployees();
                            Console.WriteLine("Employees:");
                            foreach (Employees em in employees)
                            {
                                Console.WriteLine(em.ToString());
                            }
                            Console.WriteLine(); ClearConsole(); break;
                        case 2:
                            Console.WriteLine("Clients:");
                            var clients = db.GetAllClients();
                            foreach (Clients client in clients)
                            {
                                Console.WriteLine(client.ToString());
                            }
                            Console.WriteLine(); ClearConsole(); break;
                        case 3:
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            var salesByEmployee = db.GetSallesByEmployee(name);
                            foreach (Salles sal in salesByEmployee)
                            {
                                Console.WriteLine(sal.ToString());
                            }
                            Console.WriteLine(); ClearConsole(); break;
                        case 4:
                            Console.Write("Enter price: "); decimal price = Convert.ToDecimal(Console.ReadLine());
                            var selectByPrice = db.GetSallesByPrice(price);
                            foreach (Salles sal in selectByPrice)
                            {
                                Console.WriteLine(sal.ToString());
                            }
                            Console.WriteLine(); ClearConsole(); break;
                        case 5:
                            Console.Write("Enter name: ");
                            string client_name = Console.ReadLine();
                            var minMax = db.GetMinMaxSalles(client_name);
                            foreach (Salles sal in minMax)
                            {
                                Console.WriteLine(sal.ToString());
                            }
                            Console.WriteLine(); ClearConsole(); break;
                        case 6:
                            Console.Write("Enter name: ");
                            string employee_name = Console.ReadLine();
                            var getDate = db.GetFirstByDate(employee_name);
                            Console.WriteLine(getDate.ToString()); ClearConsole(); break;
                        case 7: break;
                        default: Console.WriteLine("Invalid option. Please try again."); ClearConsole(); break;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}