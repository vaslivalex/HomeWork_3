using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Menu
    {
        public void Show()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Alex", "Ivanov", 25, "097-943-85-75", "vanya@mail.ru"));
            employees.Add(new Employee("Petr", "Petrov", 28, "097-943-85-76", "petya@mail.ru"));
            string path = @"D:\employees.txt";



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сотрудник: ");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите команду: ");
            Console.ResetColor();

            string[] commands = Console.ReadLine().Split(' ');
            if (commands[0].ToLower() == "exit" & commands.Length == 1)
            {
                return;
            }
            
            foreach (var empl in employees)
            {
                Console.Write(new String(' ', 5));
                Console.ResetColor();
                Console.WriteLine(empl.ToString());
            }


            employees.Remove();
        }
        private static string SearchToRemove(String s)
        {
            s = Console.ReadLine();
            return s.ToLower();
        }
    }
}
