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
        public int Id { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public byte Age { set; get; }
        public string PhoneNumber { set; get; }
        public string EMail { set; get; }

        public Employee(int id, string lastName, string firstName, byte age, string phoneNumber, string eMail)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            EMail = eMail;
        }

        public override string ToString()
        {
            return string.Format ("Идентификатор: {0}, фамилия: {1}, имя: {2}, возраст: {3}, телефон: {4}, e-mail: {5}", Id, LastName, FirstName, Age, PhoneNumber, EMail);
        }
    }
}
