using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте приложение, которое выводит на экран всю информацию об указанном .xml файле. 
             */

            var document = new XmlDocument();
            FileInfo file = new FileInfo("TelephoneBook.xml");
            if (!file.Exists)
            {
                Console.WriteLine("Файл не найден.");
                Console.ReadKey();
                return;
            }

            document.Load("TelephoneBook.xml");

            // Показ содержимого XML.
            Console.WriteLine(document.InnerText);

            Console.WriteLine(new string('-', 20));

            // Показ кода XML документа.
            Console.WriteLine(document.InnerXml);

            // Delay.
            Console.ReadKey();
        }
    }
}
