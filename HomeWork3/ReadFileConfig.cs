using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    class ReadFileConfig
    {
        public string ReadFromIni()
        {
            string textFromFile = "";
            if (!File.Exists("option.ini"))
            {
                TextWriter tw = new StreamWriter("option.ini", true);
                tw.WriteLine("XML");
                tw.Close();
                textFromFile = "XML";
                return textFromFile;
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader("option.ini", System.Text.Encoding.Default))
                    {
                        textFromFile = sr.ReadLine();
                    }
                    return textFromFile;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return textFromFile;
            }
        }
    }
}
