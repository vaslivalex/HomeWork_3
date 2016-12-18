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
            Dictionary<string, Employee> Empl = new Dictionary<string, Employee>();
            Empl.Add("Сотрудник1", new Employee(100, "Alex", "Ivanov", 25, "097-943-85-75", "vanya@mail.ru"));
            Empl.Add("Сотрудник2", new Employee(101, "Petr", "Petrov", 28, "097-943-85-76", "petya@mail.ru"));
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сотрудник: ");
            foreach (KeyValuePair<string, Employee> dev in Empl)
            {
                Console.Write(new String(' ', 5));
                Console.ResetColor();
                Console.WriteLine("{0,-10} {1,3}", dev.Key, dev.Value.ToString());

            }
        }
    }
}
