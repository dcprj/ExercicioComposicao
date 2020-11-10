using Exercicio01.Entities;
using Exercicio01.Entities.Enums;
using System;
using System.Globalization;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, birthDay);

            Console.WriteLine("Enter order data:");

            Console.Write("Status: PendingPayment [0] / Processing [1] / Shipped [2] / Delivered [3] ): ");

            int numStatus = int.Parse(Console.ReadLine());

            OrderStatus status = (OrderStatus)numStatus;

            Console.Write("How many items to this order? ");
            int numItems = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status , c1);

            for (int i = 1; i <= numItems; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(productQuantity, productPrice, product);
                order.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
