using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp31
{
    internal class Program
    {

        public static List<string> Names = new List<string>();
        public static List<int> Ages = new List<int>();
        public static List<string> EmploymentStatuses = new List<string>();
        public static List<string> FavSmoothies = new List<string>();
        public static List<int> SmoothiesBoughtList = new List<int>();
        public static List<int> SmoothiesConsumedList = new List<int>();
        public static List<int> TreadmillList = new List<int>();
        public static List<DateTime> JoinDateList = new List<DateTime>();
        public static List<string> Surname = new List<string>();
        public static List<string> QualifiedMembers = new List<string>();

        enum Menu
        {
            //Bruno Samartino
            Capture = 1,
            Check,
            FitForge,
            Stats,
            Exit
        }
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO FITFORGE'S MAIN MENU");
            Console.WriteLine("=========================================");

            bool yes = true;

            do
            {

                Console.WriteLine("Please enter number of desired option");
                Console.WriteLine($"{(int)Menu.Capture}.Capture Yourself");
                Console.WriteLine($"{(int)Menu.Check}. Check your information");
                Console.WriteLine($"{(int)Menu.FitForge}. FitForge Qualify");
                Console.WriteLine($"{(int)Menu.Stats} Statistics");
                Console.WriteLine($"{(int)Menu.Exit}. Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Capture();
                        break;

                    case 2:
                        Check();
                        break;

                    case 3:
                        Fitforge();
                        break;

                    case 4:
                        ShowStatistics();
                        break;

                    case 5:
                        Exit();
                        break;
                }
                Console.WriteLine("Would you like to go to the main menu? (Y/N)");
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
            string name, Employment, FavSmoothie, input, Surname1;
            char Cchoice;
            int age, SmoothiesBought, SmoothiesConsumed, Traedmill;
            Console.Write("Name Please: ");
            name = Console.ReadLine();

            Console.Write("Surname Please: ");
            Surname1 = Console.ReadLine();

            Console.Write("Age Please:");
            age = int.Parse(Console.ReadLine());
            if (age > 18)
            {
                Console.Write($"Employment status(Press Y/N): ");
                Employment = Console.ReadLine();
            }
            else

            {
                Console.Write($"Employment status of Gurdian(Press Y/N): ");
                Employment = Console.ReadLine();

            }

            Console.Write("Personal treadmill distance in km ");
            Traedmill = int.Parse(Console.ReadLine());

            Console.Write("Join date as a loyal member:");
            //DX
            Console.WriteLine("Enter date in this manner (DD/MM/YYYY): ");
            input = Console.ReadLine();
            DateTime date = DateTime.Parse(input);
            Console.WriteLine($"You entered: {date:dd/MM/yyyy}");
            //

            Console.WriteLine("Favourite smoothie flavour: (Provide letter in brackets) ");
            Console.WriteLine("Chocolate (C)");
            Console.WriteLine("Blueberry(B)");
            Console.WriteLine("Banana (A)");
            Console.WriteLine("Mango (M)");
            Console.WriteLine("Strawberry (S)");
            Console.WriteLine("Other (Z): ");
            Cchoice = char.Parse(Console.ReadLine().ToUpper());
            switch (Cchoice)
            {
                case 'C':
                    FavSmoothie = "Chocolate";
                    break;

                    case 'B':
                    FavSmoothie = "Blueberry";
                    break;

                    case 'A':
                    FavSmoothie = "Banana";
                    break;

                    case 'M':
                    FavSmoothie = "Mango";
                    break;

                    case 'S':
                    FavSmoothie = "Strawberry";
                    break;
                    case 'Z':
                    FavSmoothie = "Other";
                    break;
                    default: 
                    Console.WriteLine("Invalid input, please enter a valid option (C/B/A/M/S/Z).");
                    return;

            }
          
            Console.Write("Number of smoothies consumed since joining: ");
            SmoothiesConsumed = int.Parse(Console.ReadLine());

            Console.Write("Number of smoothies bought: ");
            SmoothiesBought = int.Parse(Console.ReadLine());
            //


            Names.Add(name);
            Surname.Add(Surname1);
            Ages.Add(age);
            JoinDateList.Add(date);
            SmoothiesBoughtList.Add(SmoothiesBought);
            SmoothiesConsumedList.Add(SmoothiesConsumed);
            TreadmillList.Add(Traedmill);
            switch (Employment.ToUpper())
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
            switch (Cappy)
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
                Console.WriteLine($"Name and Surname: {Names[i]} {Surname[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Join Date: {JoinDateList[i]:dd/MM/yyyy}");
                Console.WriteLine($"Employment Status: {EmploymentStatuses[i]}");
                Console.WriteLine($"Favorite Smoothie: {FavSmoothies[i]}");
                Console.WriteLine($"Smoothies Bought: {SmoothiesBoughtList[i]}");
                Console.WriteLine($"Smoothies Consumed: {SmoothiesConsumedList[i]}");
                Console.WriteLine($"Treadmill Distance: {TreadmillList[i]} km");

            }
        }
        public static void Fitforge()
        {
            DateTime now = DateTime.Now;
            QualifiedMembers.Clear();

            for (int i = 0; i < Names.Count; i++)
            {
                bool isEmployed = EmploymentStatuses[i] == "Employed" || (Ages[i] < 18 && EmploymentStatuses[i] == "Employed");

                TimeSpan membershipDuration = now - JoinDateList[i];
                bool hasTwoYears = membershipDuration.TotalDays >= 730;

                int ageRank = Ages[i] * 100;
                bool rankQualifies = ageRank > 2000 || TreadmillList[i] > 20;

                double monthsAsMember = membershipDuration.TotalDays / 30.0;
                double avgSmoothiesPerMonth = monthsAsMember > 0 ? SmoothiesConsumedList[i] / monthsAsMember : 0;

                bool drinksEnough = avgSmoothiesPerMonth >= 4;
                bool drinksTooMuch = avgSmoothiesPerMonth > 20;
                bool bannedFlavor = FavSmoothies[i].Equals("ChocoChurned Chaos", StringComparison.OrdinalIgnoreCase);

                if (isEmployed && hasTwoYears && rankQualifies && drinksEnough && !drinksTooMuch && !bannedFlavor)
                {
                    QualifiedMembers.Add($"{Names[i]} {Surname[i]}");
                }
            }

            Console.WriteLine("\n--- Qualified Members for Wellness Reward ---");
            if (QualifiedMembers.Count == 0)
            {
                Console.WriteLine("No one qualifies, ya lazy bums!");
            }
            else
            {
                foreach (var member in QualifiedMembers)
                {
                    Console.WriteLine(member);
                }
            }

        }
        public static void ShowStatistics()
        {
            if (Names.Count == 0)
            {
                Console.WriteLine("No data available to show statistics.");
                return;
            }

            double avgAge = Ages.Average();
            double avgTreadmill = TreadmillList.Average();
            double avgSmoothiesBought = SmoothiesBoughtList.Average();
            double avgSmoothiesConsumed = SmoothiesConsumedList.Average();

            int maxTreadmill = TreadmillList.Max();
            int minTreadmill = TreadmillList.Min();

            Console.WriteLine("\n--- Member Statistics ---");
            Console.WriteLine($"Average Age: {avgAge:F2}");
            Console.WriteLine($"Average Treadmill Distance: {avgTreadmill:F2} km");
            Console.WriteLine($"Average Smoothies Bought: {avgSmoothiesBought:F2}");
            Console.WriteLine($"Average Smoothies Consumed: {avgSmoothiesConsumed:F2}");
            Console.WriteLine($"Maximum Treadmill Distance: {maxTreadmill} km");
            Console.WriteLine($"Minimum Treadmill Distance: {minTreadmill} km");
        }

        public static void Exit()
        {
            Console.WriteLine("Thank you for using FitForge, Goodbye!");
            Environment.Exit(0);
        }
    }
}