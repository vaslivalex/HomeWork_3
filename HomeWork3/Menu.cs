using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Menu
    {
        public void Show()
        {
            Dictionary<string, Employee> empl = new Dictionary<string, Employee>();
            empl.Add("Сотрудник 1", new Employee(100, "Alex", "Ivanov", 25, "097-943-85-75", "vanya@mail.ru"));
            empl.Add("Сотрудник 2", new Employee(101, "Petr", "Petrov", 28, "097-943-85-76", "petya@mail.ru"));
            
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
            
            foreach (var dev in empl)
            {
                Console.Write(new String(' ', 5));
                Console.ResetColor();
                Console.WriteLine(dev.ToString());
            }
           
            empl.Remove("Сотрудник 1");
        }
    }
}
