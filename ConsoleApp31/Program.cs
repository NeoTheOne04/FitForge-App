using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp31
{
    internal class Program
    {
        // Class-level lists - add these here
        public static List<string> Names = new List<string>();
        public static List<int> Ages = new List<int>();
        public static List<string> EmploymentStatuses = new List<string>();
        public static List<string> FavSmoothies = new List<string>();
        public static List<int> SmoothiesBoughtList = new List<int>();
        public static List<int> SmoothiesConsumedList = new List<int>();
        public static List<int> TreadmillList = new List<int>();
        public static List<DateTime> JoinDateList = new List<DateTime>();
        public static List<string> Surname = new List<string>();

        enum Menu
        {
            Capture = 1,
            Check,
            FitForge,
            Exit
        }
        static void Main(string[] args)
        {
          
         
            bool yes = true;

            do
            {
                Console.WriteLine("Welcome to FitForge, What can I do for you?");
                Console.WriteLine($"1. Capture Yourself?");
                Console.WriteLine($"2. Check your information?");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Capture();
                        break;
                    case 2:
                        Check();
                        break;
                }
                Console.WriteLine("Would you like to redo this (Y/N)");
                char redo = char.Parse(Console.ReadLine().ToUpper());
                switch (redo)
                {
                    case 'Y':
                        yes = true;
                        break;
                    case 'N':
                        yes = false;
                        Console.WriteLine("Thank you for using FitForge, Goodbye!");
                        break;
                }
            }
            while (yes);
        }
        public static void Capture()
        {
            string name, Employment, FavSmoothie, input,Surname1;
            int age, SmoothiesBought, SmoothiesConsumed, Traedmill;
            Console.Write("Name Please:");
            name = Console.ReadLine();

                Console.Write("Surname Please:");
                Surname1 = Console.ReadLine();
               
            Console.Write("Age Please:");
            age = int.Parse(Console.ReadLine());

            Console.Write($"Employment status(Press Y/N): ");
            Employment = Console.ReadLine();

            Console.Write("Personal treadmill distance in km");
            Traedmill = int.Parse(Console.ReadLine());

            Console.Write("Join date as a loyal member:");
            //
            Console.WriteLine("Enter date in this manner (DD/MM/YYYY):");
            input = Console.ReadLine();
            DateTime date = DateTime.Parse(input);
            Console.WriteLine($"You entered: {date:dd/MM/yyyy}");
            //

            Console.Write("Favourite smoothie flavour");
            FavSmoothie = Console.ReadLine();
            Console.Write("Number of smoothies consumed since joining:");
            SmoothiesConsumed = int.Parse(Console.ReadLine());

            Console.Write("Number of smoothies bought:");
            SmoothiesBought = int.Parse(Console.ReadLine());

          

            Names.Add(name);
            Surname.Add(Surname1);
            Ages.Add(age);
            JoinDateList.Add(date);
            SmoothiesBoughtList.Add(SmoothiesBought);
            SmoothiesConsumedList.Add(SmoothiesConsumed);
            TreadmillList.Add(Traedmill);
            switch(Employment.ToUpper())
            {
                case "Y":
                    Employment = "Employed";
                    break;
                case "N":
                    Employment = "Unemployed";
                    break;
                default:
                    Console.WriteLine("Invalid input, please enter Y or N.");
                    return; 
            }
            EmploymentStatuses.Add(Employment);
            FavSmoothies.Add(FavSmoothie);

            Console.WriteLine("Thank you for your information, we will now process it!");

            Console.WriteLine("Would you like to add someone else");
            Console.WriteLine("Y/N");
            char Cappy = Console.ReadLine().ToUpper()[0];
            switch(Cappy) 
            {
                case 'Y':
                    Capture();
                    break;
                case 'N':
                    Console.WriteLine("Thank you for using FitForge, Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input, please enter Y or N.");
                    break;
            }

        }
        public static void Check()
        {
            Console.WriteLine("Here is your information:");

            for (int i = 0; i < Names.Count; i++)
            {
                Console.WriteLine($"--- Member #{i + 1} ---");
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Join Date: {JoinDateList[i]:dd/MM/yyyy}");
                Console.WriteLine($"Employment Status: {EmploymentStatuses[i]}");
                Console.WriteLine($"Favorite Smoothie: {FavSmoothies[i]}");
                Console.WriteLine($"Smoothies Bought: {SmoothiesBoughtList[i]}");
                Console.WriteLine($"Smoothies Consumed: {SmoothiesConsumedList[i]}");
                Console.WriteLine($"Treadmill Distance: {TreadmillList[i]} km");
                Console.WriteLine("--------------------------");
            }
        }
    }
}