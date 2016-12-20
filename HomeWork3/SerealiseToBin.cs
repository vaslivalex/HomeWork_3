using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HomeWork3
{
    class SerealiseToBin
    {
        public void SerializeList(List<Employee> list)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream fstream = new FileStream(@"D:\employees.txt", FileMode.OpenOrCreate))
            {
                binForm.Serialize(fstream, list);
            }
        }
        public List<Employee> DeserializeList()
        {
            if (File.Exists(@"D:\employees.txt"))
            {
                BinaryFormatter binForm = new BinaryFormatter();
                List<Employee> employees;
                using (FileStream fstream = new FileStream(@"D:\employees.txt", FileMode.OpenOrCreate))
                {
                    binForm = (List<Employee>)binForm.Deserialize(fstream);
                }
                return binForm;
            }
            else
            {
                return new List<Employee>();
            }
        }
    }      
}
