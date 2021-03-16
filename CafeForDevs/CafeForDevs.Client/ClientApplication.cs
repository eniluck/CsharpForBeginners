using System;
using System.Text;

namespace CafeForDevs.Client
{
    internal class ClientApplication
    {
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
                    "\n\t3) Вывести информацию о своем заказе"+
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

       
    }
}
