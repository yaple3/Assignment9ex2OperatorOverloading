using System;

namespace Assignment9ex2OperatorOverloading
{
    public class Log
    {
        public string Activity { get; set; }
        public double Hours { get; set; }
        public string? Category { get; set; } //Fun,Work,Other

        // overloaded operator ++ and operator --
        public static Log operator ++(Log log)
        {
            log.Hours++;
            return log;
        }
        public static Log operator --(Log log)
        {
            log.Hours--;
            return log;
        }

        // overloaded operator + and operator -
        public static Log operator +(Log log, int hours)
        {
            log.Hours += hours;
            return log;
        }
        public static Log operator -(Log log, int hours)
        {
            log.Hours -= hours;
            return log;
        }

        // overloaded operator > and operator <
        public static bool operator >(Log log1, Log log2)
        {
            return log1.Hours > log2.Hours;
        }
        public static bool operator <(Log log1, Log log2)
        {
            return log1.Hours < log2.Hours;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Log[] myLog = new Log[100];
            for (int i = 0; i < myLog.Length; i++)
            {
                myLog[i] = new Log();  // creates objects
            }
            int selection = Menu();
            int index = 0, entry = 0;
            string ans = "";
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 100)
                        {
                            Console.Write("Activity Category (Fun, Work, Other): ");
                            myLog[index].Category = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Activity: ");
                            myLog[index].Activity = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Hours: ");
                            myLog[index].Hours = double.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                            Console.WriteLine("You have too many log entries - see programming");
                        break;
                    case 2:
                        for (int i = 0; i < myLog.Length; i++)
                        {
                            if (myLog[i].Activity != "" && myLog[i].Activity != null)
                            {
                                Console.WriteLine($"Category: {myLog[i].Category}");
                                Console.WriteLine($"Activity: {myLog[i].Activity}");
                                Console.WriteLine($"Hours: {myLog[i].Hours}");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.Write("Change Activity Category (Fun, Work, Other) Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Category? ");
                            myLog[entry].Category = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.Write("Change Activity Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Activity: ");
                            myLog[entry].Activity = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        entry = pickEntry(index);

                        Console.Write("Increase Hours by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator++ method
                            myLog[entry]++;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease Hours by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator-- method
                            myLog[entry]--;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Increase Hours by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the hours: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please enter a number");
                            // calls the operator+ method
                            // the method should receive an 
                            // object and a integer as arguments
                            myLog[entry] += hr;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease Hours by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the hours: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please a number");
                            // calls the operator- method
                            // the method should receive an 
                            // object and an integer as arguments
                            myLog[entry] -= hr;
                            Console.WriteLine();
                            break;
                        }

                        break;
                    case 5:
                        Log totalFun = new Log();
                        totalFun.Category = "Fun Category";
                        totalFun.Activity = "Total Fun Hours";
                        Log totalWork = new Log();
                        totalWork.Category = "Work Category";
                        totalWork.Activity = "Total Work Hours";
                        Log totalOther = new Log();
                        totalOther.Category = "Other Category";
                        totalOther.Activity = "Total Other Hours";
                        for (int i = 0; i < myLog.Length; i++)
                        {
                            switch (myLog[i].Category)
                            {
                                case "Fun":
                                    totalFun.Hours += myLog[i].Hours;
                                    break;
                                case "Work":
                                    totalWork.Hours += myLog[i].Hours;
                                    break;
                                case "Other":
                                    totalOther.Hours += myLog[i].Hours;
                                    break;
                            }
                        }
                        Console.WriteLine("Total Hours by Category");
                        // calls operator >
                        if (totalFun > totalWork && totalFun > totalOther)
                        {
                            Console.WriteLine("The largest number of hours was spent on fun!");
                            Console.WriteLine($"Your total fun hours = {totalFun.Hours}");
                            Console.WriteLine($"Your total work hours = {totalWork.Hours}");
                            Console.WriteLine($"Your total other hours = {totalOther.Hours}");
                        }
                        // calls operator >
                        else if (totalWork > totalFun && totalWork > totalOther)
                        {
                            Console.WriteLine("The largest number of hours was spent on work");
                            Console.WriteLine($"Your total work hours = {totalWork.Hours}");
                            Console.WriteLine($"Your total fun hours = {totalFun.Hours}");
                            Console.WriteLine($"Your total other hours = {totalOther.Hours}");
                        }
                        else
                        {
                            Console.WriteLine("The largest number of hours was spent on other activities");
                            Console.WriteLine($"Your total other hours = {totalOther.Hours}");
                            Console.WriteLine($"Your total work hours = {totalWork.Hours}");
                            Console.WriteLine($"Your total fun hours = {totalFun.Hours}");
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection, please try again");
                        break;
                }
                selection = Menu();

            }
        }
        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1 - Add an entry");
            Console.WriteLine("2 - Print All");
            Console.WriteLine("3 - Change category or activity");
            Console.WriteLine("4 - Adjust hours");
            Console.WriteLine("5 - Total categories and compare");
            Console.WriteLine("6 - Quit");
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please select 1 - 6");
            return choice;
        }
        public static int pickEntry(int index)
        {
            Console.WriteLine("What entry would you like to change?");
            Console.WriteLine($"1 through {index}");
            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select 1 - {index}");
            entry -= 1;  // subtract 1 to begin index at 0
            return entry;
        }
    }
}