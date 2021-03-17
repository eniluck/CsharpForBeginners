using System;
using System.Text;

namespace CafeForDevs.Client
{
    internal class ClientApplication
    {
        private ICafeHttpClient _cafeHttpClient;

        internal ClientApplication(ICafeHttpClient cafeHttpClient)
        {
            _cafeHttpClient = cafeHttpClient;
        }

        internal void Start()
        {
            Console.WriteLine("ClientApplication started");

            bool IsUserContinue = true;
            string userAnswer;
            do
            {
                Console.WriteLine("Выберите пункт меню: " +
                    "\n\t1) Вывести меню ресторана" +
                    "\n\t2) Выбрать блюдо из меню" +
                    "\n\t3) Вывести информацию о своем заказе" +
                    "\n\t4) Оплатить заказ");
                userAnswer = Console.ReadLine();

                //сделать првоерку на число из пункта меню

                switch (userAnswer)
                {
                    case "1": break;
                    case "2": break;
                    case "3": break;
                }

                Console.WriteLine("Будем продолжать? (y/n)");
                userAnswer = Console.ReadLine();

                IsUserContinue = userAnswer.ToUpper() == "Y";
            } while (IsUserContinue);
        }

        internal void PrintMenu()
        {
            var menu = _cafeHttpClient.GetMenu();

            foreach (var item in menu.Items)
            {
                Console.WriteLine($"№{item.Id}: {item.Name} - {item.Price}");
            }
        }

        internal void SelectMenuItem()
        {
            Console.WriteLine("Введите номер блюда.");
            var userAnswer = Console.ReadLine();
            var menuItemId = int.Parse(userAnswer);

            _cafeHttpClient.SelectMenuItem(menuItemId);
        }

        internal void PrintOrder()
        {
            _cafeHttpClient.GetOrder();
        }
    }


    public class Order
    {

    }
}
