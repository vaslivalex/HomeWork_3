using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork3
{
    class SerializeToXml
    {
        public void SerializeXml(List<Employee> list)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Employee));
            using (FileStream fstream = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                xmlser.Serialize(fstream, list);
            }
        }
        public List<Employee> DeserializeList()
        {
            if (File.Exists("employees.xml"))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(Employee));
                List<Employee> newEmployee;
                using (FileStream fstream = new FileStream("employees.xml", FileMode.OpenOrCreate))
                {
                    newEmployee = (List<Employee>)xmlser.Deserialize(fstream);
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
