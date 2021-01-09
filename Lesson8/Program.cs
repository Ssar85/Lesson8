using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            prep();
        }
        static void prep()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Name) | string.IsNullOrEmpty(Properties.Settings.Default.Age) | string.IsNullOrEmpty(Properties.Settings.Default.Work))
            {
                UserName();
            }
            else
            {
                HelloMenu();
            }
        
        }
        
        static void HelloMenu()
        {
            string name = Properties.Settings.Default.Name;
            string resultdef = ($"{ Properties.Settings.Default.Name} { Properties.Settings.Default.Age}  { Properties.Settings.Default.Work}");
            Console.WriteLine($"Приветствую {name} ваши данные {resultdef}");
            Console.WriteLine("Введите 1 что бы их изменить 2 что бы закрыть программу");
            int menu =Convert.ToInt32 (Console.ReadLine());
            if (menu==1)
            {
                UserName();
            }
            if (menu == 2)
            {
                Console.WriteLine($"Пока {name}");
            }
        }

        static (string name, string age, string work, string result) UserName()
        {
            Console.WriteLine("Введите имя пользоавтеля:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            string age = Console.ReadLine();
            Console.WriteLine("Ваш род деятельности:");
            string work = Console.ReadLine();
            string result = $"{name} {age} {work}";
            Check(name, age, work,result);
            return (name, age, work, result) ;
            
        }
        static void Check(string name, string age, string work, string result)
        {
            if (name.Length < 1 | age.Length < 1 | work.Length < 1)
            {
                Console.WriteLine("Вы заполнили не все данные, попробуем еще раз");
                UserName();
            }
            else
            {
                UserRec(name, age, work, result);
            }
        }

        static void UserRec(string name, string age, string work, string result)
        {
            Properties.Settings.Default.Name = name;
            Properties.Settings.Default.Age = age;
            Properties.Settings.Default.Work = work;
            Properties.Settings.Default.Save();
            Console.WriteLine($"Введенные данные {result} успешно записаны в настройки приложения");

        }
    }
}
