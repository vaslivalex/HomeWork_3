using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    [Serializable]
    public class Employee
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public byte Age { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }

        public Employee(string firstName, string lastName, byte age, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return string.Format ("Фамилия: {0}, имя: {1}, возраст: {2}, телефон: {3}, e-mail: {4}", LastName, FirstName, Age, PhoneNumber, Email);
        }
    }
}
