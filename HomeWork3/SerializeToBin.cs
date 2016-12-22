using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HomeWork3
{
    class SerializeToBin
    {
        public void SerializeBin(List<Employee> list)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream fstream = new FileStream("employees.bin", FileMode.OpenOrCreate))
            {
                binForm.Serialize(fstream, list);
            }
        }
        public List<Employee> DeserializeList()
        {
            if (File.Exists("employees.bin"))
            {
                BinaryFormatter binForm = new BinaryFormatter();
                List<Employee> newEmployee;
                using (FileStream fstream = new FileStream("employees.bin", FileMode.OpenOrCreate))
                {
                    newEmployee = (List<Employee>)binForm.Deserialize(fstream);
                }
                return newEmployee;
            }
            else
            {
                return new List<Employee>();
            }
        }
    }      
}
