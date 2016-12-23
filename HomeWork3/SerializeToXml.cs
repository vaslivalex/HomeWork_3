using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork3
{
    public class SerializeToXml
    {
        public void SerializeXml(List<Employee> list)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fstream = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                xmlser.Serialize(fstream, list);
            }
        }
        public List<Employee> DeserializeList()
        {

            if (File.Exists("employees.xml"))
            {
                try
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(List<Employee>));
                    List<Employee> newEmployee;
                    using (FileStream fstream = new FileStream("employees.xml", FileMode.OpenOrCreate))
                    {
                        newEmployee = (List<Employee>)xmlser.Deserialize(fstream);
                    }
                    return newEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ахтунг!! АшЫпка, файла XML!!!");
                    return new List<Employee>();
                }
            }
            else
            {
                return new List<Employee>();
            }
        }
    }
}
