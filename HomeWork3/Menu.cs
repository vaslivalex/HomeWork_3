using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Menu
    {
        List<Employee> employeesList;
        ReadFileConfig rfc = new ReadFileConfig();
        SerializeToBin binSerializer;
        SerializeToXml xmlSerializer;
        public void Show()
        {
            if (rfc.ReadFromIni().ToLower() == "xml")
            {
                xmlSerializer = new SerializeToXml();
                employeesList = (List<Employee>)xmlSerializer.DeserializeList();
            }
            else if (rfc.ReadFromIni().ToLower() == "bin")
            {
                binSerializer = new SerializeToBin();
                employeesList = (List<Employee>)binSerializer.DeserializeList();
            }
            else
            {
                TextWriter tw = new StreamWriter("option.ini", true);
                tw.WriteLine("xml");
                tw.Close();
                Console.WriteLine("Ошибка файла конфигурации!");
                Console.WriteLine("Файл был автоматически восстановлен.");
            }

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Введите команду: ");
                Console.ResetColor();


                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" && commands.Length == 1)
                {
                    return;
                }
                if (commands[0].ToLower() == "help" && commands.Length == 1)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && commands.Length == 1)
                {
                    string temp;
                    string reg;
                    int id;
                    string lastName;
                    string firstName;
                    byte age;
                    string phoneNumber;
                    string eMail;
                    bool idIsExist = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nЗаполнение данных о сотруднике.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("1. Введите идентификатор:  ");

                    Console.ResetColor();
                    temp = Console.ReadLine();
                    if (!Int32.TryParse(temp, out id))
                    {
                        Error();
                        continue;
                    }
                    foreach (Employee empl in employeesList)
                    {
                        if (empl.Id == id)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка!\nСотрудник с таким ID уже сществует!");
                            Console.ResetColor();
                            Console.ReadLine();
                            idIsExist = true;
                        }
                    }
                    if (idIsExist)
                    {
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("2. Введите фамилию:        ");
                    Console.ResetColor();
                    temp = Console.ReadLine();
                    reg = @"[a-zA-Zа-яА-Я]{1}[a-zа-я]*";
                    if (Regex.IsMatch(temp, reg))
                    {
                        lastName = temp;
                    }
                    else
                    {
                        Error();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("3. Введите имя:            ");
                    Console.ResetColor();
                    temp = Console.ReadLine();
                    reg = @"[a-zA-Zа-яА-Я]{1}[a-zа-я]*";
                    if (Regex.IsMatch(temp, reg))
                    {
                        firstName = temp;
                    }
                    else
                    {
                        Error();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("4. Введите возраст:        ");
                    Console.ResetColor();
                    temp = Console.ReadLine();
                    if (!Byte.TryParse(temp, out age))
                    {
                        Error();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("5. Введите номер телефона: ");
                    Console.ResetColor();
                    Console.Write("+38");
                    temp = Console.ReadLine();
                    reg = @"[0]\d{9}";
                    if (Regex.IsMatch(temp, reg))
                    {
                        phoneNumber = temp;
                    }
                    else
                    {
                        Error();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("6. Введите E-mail:         ");
                    Console.ResetColor();
                    temp = Console.ReadLine();
                    reg = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b";
                    if (Regex.IsMatch(temp, reg))
                    {
                        eMail = temp;
                    }
                    else
                    {
                        Error();
                        continue;
                    }
                    employeesList.Add(new Employee(id, lastName, firstName, age, phoneNumber, eMail));
                    Console.WriteLine("Сотрудник добавлен в базу данных!");
                }
                if (commands[0].ToLower() == "exit" && commands.Length == 1)
                {
                    xmlSerializer.SerializeXml(employeesList);
                }
                else if (commands[0].ToLower() == "exit" && commands.Length == 1 && rfc.ReadFromIni().ToLower() == "bin")
                {
                    binSerializer.SerializeBin(employeesList);
                }

                if (commands[0].ToLower() == "del" && commands.Length == 2)
                {
                    int del;
                    if (!Int32.TryParse(commands[1], out del))
                    {
                        Help();
                        continue;
                    }
                    else
                    {
                        Int32.TryParse(commands[1], out del);
                        for (int i = 0; i < employeesList.Count; i++)
                        {
                            if (employeesList[i].Id == del)
                            {
                                employeesList.RemoveAt(i);
                                Console.WriteLine("Данные сотрудника удалены!");
                                Console.ReadLine();
                            }
                        }
                    }
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
                else
                {
                    Help();
                }
            }
        }
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНеверный формат данных");
            Console.ResetColor();
            Console.ReadLine();
        }
        private void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("\thelp       - добавить сотрудника");
            Console.WriteLine("\tadd        - добавить сотрудника");
            Console.WriteLine("\tsee_all    - посмотреть список сотрудников");
            Console.WriteLine("\tdel ID     - удалить сотрудника по идентификатору");
            Console.WriteLine("\tfind ID    - найти сотрудника по идентификатору");
            Console.WriteLine("\texit       - выход");
        }
    }
}

