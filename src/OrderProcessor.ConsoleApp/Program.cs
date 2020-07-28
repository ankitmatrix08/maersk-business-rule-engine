using OrderProcessor.Domain;
using OrderProcessor.Models;
using OrderProcessor.Models.Models;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Customer!");
            Console.WriteLine("Please Enter the Product details for your order:");
            var order = new Order();
            Console.WriteLine("Please enter your Full Name -  E.g. Mark Smith");
            order.CustomerFullName = Console.ReadLine();

            Console.WriteLine("Please enter your Email address -  E.g. mark.smith@abc.com");
            var inputEmail = Console.ReadLine();
            while (!Regex.Match(inputEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid email entered, please type in a valid email");
                Console.ResetColor();
                inputEmail = Console.ReadLine();
            }
            order.CustomerEmail = inputEmail;


            Console.WriteLine("Please enter the street you live");
            order.StreetLine = Console.ReadLine();

            Console.WriteLine("Please enter your City Name");
            order.City = Console.ReadLine();

            Console.WriteLine("Please enter your State's name");
            order.State = Console.ReadLine();

            Console.WriteLine("Please enter your Pin/Zip code - has to be exactly 6 chars/digits");
            var input = Console.ReadLine();
            while (!Regex.Match(input, @"^\d{6}$").Success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid Zip code entered - has to be exactly 6 chars/digits");
                Console.ResetColor();
                input = Console.ReadLine();
            }
            order.PinCode = input;

            Console.WriteLine("Out of these below please enter the digit of the product you would like to place an order for");
            Console.WriteLine("1 --- PhysicalProduct\n2 --- A Book\n3 --- Activate your membership\n4 --- Upgrade your membership\n5 --- LearningVideo");
            int.TryParse(Console.ReadLine(), out int inputProduct);
            while (inputProduct <= 0 || inputProduct > 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid Product code entered - has to be between 1 to 5");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out inputProduct);
            }
            order.OrderType = (OrderItem)inputProduct;

            Console.WriteLine("Please enter the number of Qty between 1 to 10 only");

            int.TryParse(Console.ReadLine(), out int qty);
            while (qty <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter a valid number between 1 to 10 only");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out qty);
            }
            order.Quantity = qty;

            if (order.OrderType == OrderItem.LearningVideo)
            {
                Console.WriteLine("Please enter the learning video's name");
                order.VideoName = Console.ReadLine();
            }

            OrderFacade orderFacade = new OrderFacade(order);
            orderFacade.StartProcessing();

        }
    }
}
