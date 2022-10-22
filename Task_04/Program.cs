using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте .xml файл, который соответствовал бы следующим требованиям: 
             * • имя файла: TelephoneBook.xml 
             * • корневой элемент: “MyContacts” 
             * • тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber” со значением номера телефона.
             */

            var xmlWriter = new XmlTextWriter(@".\TelephoneBook.xml", null);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("380939876543");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Залужний Сегрій Іванович");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            Console.ReadKey();
        }
    }
}
