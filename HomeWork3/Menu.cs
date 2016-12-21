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
            List<Employee> employeesList = new List<Employee>();
            ReadFileConfig rfc = new ReadFileConfig();
            SerializeToBin binSerializer;
            SerializeToXml xmlSerializer;

            if (rfc.ReadFromIni() == "XML")
            {
                xmlSerializer = new SerializeToXml();
                employeesList = (List<Employee>)xmlSerializer.DeserializeList();
            }
            else if (rfc.ReadFromIni() == "BIN")
            {
                binSerializer = new SerializeToBin();
                employeesList = (List<Employee>)binSerializer.DeserializeList();
            }
            else
            {
                TextWriter tw = new StreamWriter("option.ini", true);
                tw.WriteLine("XML");
                tw.Close();
                Console.WriteLine("Ошибка файла конфигурации!");
                Console.WriteLine("Файл конфигурации восстановлен.");
            }
            Console.ReadLine();
            //List<Employee> employees = new List<Employee>();
            //employees.Add(new Employee("Alex", "Ivanov", 25, "097-943-85-75", "vanya@mail.ru"));
            //employees.Add(new Employee("Petr", "Petrov", 28, "097-943-85-76", "petya@mail.ru"));
            //string path = @"D:\employees.txt";

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Введите команду: ");
                Console.ResetColor();


                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0] == "exit" && commands.Length == 1)
                {
                    return;
                }
                if (commands[0] == "help" || commands.Length > 2)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && commands.Length == 1)
                {
                    //employees.Add());
                }
                if (commands[0].ToLower() == "del" && commands.Length == 1)
                {
                    //employees.Remove());
                }
                if (commands[0].ToLower() == "see_all" && commands.Length == 1)
                {
                    foreach (var empl in employeesList)
                    {
                        Console.Write(new String(' ', 5));
                        Console.ResetColor();
                        Console.WriteLine(empl.ToString());
                    }
                }
            }
        }

        private void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd -          добавить сотрудника");
            Console.WriteLine("\tdel -          удалить сотрудника");
            Console.WriteLine("\tsee_all -      посмотреть весь список сотрудников");
            Console.WriteLine("\tsee_concr -    посмотреть конкретного сотрудника");
        }
    }
}



//Console.Clear();
//Console.ForegroundColor = ConsoleColor.Yellow;
//Console.WriteLine("Сотрудник: ");








//employees.Remove();


//private static string SearchToRemove(String s)
//{
//    s = Console.ReadLine();
//    return s.ToLower();
//}

