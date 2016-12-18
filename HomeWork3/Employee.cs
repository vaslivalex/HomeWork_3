using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class Employee
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public byte Age { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }

        public Employee(int id, string firstName, string lastName, byte age, string phoneNumber, string email)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return ("ID: " + ID + ", фамилия: " + LastName + ", имя: " + FirstName + ", возраст: " + Age + ", номер тел.: " + PhoneNumber + ", email: " + Email);
        }
    }
}
