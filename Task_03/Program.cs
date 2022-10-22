using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Configuration;

namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Используя примеры, рассмотренные на уроке, создайте свое приложение для администратора, которое будет сохранять данные конфигурации в специальном файле или в реестре. 
             * Создайте пользовательское приложение, которым можно управлять при помощи админприложения.
             */

            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string role;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Укажите роль (Admin, User)");
                role = Console.ReadLine();

                switch (role)
                {
                    case "Admin":
                        ActionAdmin(appSettings);
                        break;
                    case "User":
                        ActionUser(appSettings);
                        return;
                    default:
                        Console.WriteLine("Роли не существует. Повторите снова.");
                        continue;
                }

            }
        }

        public static void GetSettings(NameValueCollection appSettings, out int difficulty, out int attempts)
        {
            difficulty = int.Parse(appSettings["Difficulty"]);
            attempts = int.Parse(appSettings["NumberOfAttempts"]);
        }
        public static void ActionAdmin(NameValueCollection appSettings)
        {
            Console.WriteLine("Вкажiть рiвень складностi (1-3): ");
            int.TryParse(Console.ReadLine(), out int difficulty);

            if (!(difficulty > 0 && difficulty < 4))
                difficulty = 1;

            appSettings["Difficulty"] = difficulty.ToString();

            Console.WriteLine("Вкажiть кiлькiсть спроб: ");
            int.TryParse(Console.ReadLine(), out int attempts);

            if (!(difficulty > 0 && difficulty < 10))
                attempts = 5;

            appSettings["NumberOfAttempts"] = attempts.ToString();
        }
        public static void ActionUser(NameValueCollection appSettings)
        {
            Console.WriteLine("Вiтаю Вас в грi 'Вгадай число або помри'");

            GetSettings(appSettings, out int dif, out int att);

            Console.WriteLine($"Cкладнiсть: {dif}");
            Console.WriteLine($"Кiлькiсть спроб: {att}");

            Random random = new Random();
            int secretNumber = random.Next(0, 10 * dif);
            bool win = false;

            for (int i = 0; i < att; i++)
            {
                Console.Write("Вкажiть число: ");
                int.TryParse(Console.ReadLine(), out int answer);
                if (secretNumber == answer)
                {
                    Console.WriteLine("Ура!");
                    return;
                }
                else
                    Console.WriteLine("Не вгадали!");
            }

            if (win)
                Console.WriteLine("Вiтаю. Ви вгадали!");
            else
                Console.WriteLine($"На жаль, {secretNumber}. Можливо наступного разу повезе, але не факт!");
            Console.ReadKey();
        }
    }
}
