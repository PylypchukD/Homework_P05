using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
			/*
             * Из файла TelephoneBook.xml (файл должен был быть создан в процессе выполнения дополнительного задания) выведите на экран только номера телефонов.  
             */

			FileInfo file = new FileInfo("TelephoneBook.xml");
			if (!file.Exists)
			{
				Console.WriteLine("Файл не найден.");
				Console.ReadKey();
				return;
			}

			FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);

			XmlTextReader xmlReader = new XmlTextReader(stream);

            Console.WriteLine("Телефоны: ");

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if (xmlReader.HasAttributes)
                    {
                        while (xmlReader.MoveToNextAttribute())
                        {
                            Console.WriteLine($"{xmlReader.Value}");
                        }
                    }
                }
            }

            xmlReader.Close();
			stream.Close();

			// Delay.
			Console.ReadKey();
		}
    }
}
