using System;

namespace Shop_homework15
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             В программе должен быть интерфейс взаимодействия с пользователем в виде простого консольного меню. 
             При выполнении операций программа не должна закрываться, для выхода из программы следует сделать отдельную операцию
            */

            do
            {
                Console.Clear();
                ShowMenu();
                GetUserInput();

            } while (true);
        }

        private static int GetUserInput()
        {
            Console.WriteLine("Выбирай пункт меню: ");
            string userInput = Console.ReadLine();
            bool isInt;
            int menuItem;
            do
            {
                userInput = Console.ReadLine();
                isInt = Int32.TryParse(userInput, out menuItem);

            } while (
                    (menuItem <0 || menuItem > 6)  
                    || isInt == false
            );
            return menuItem;
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Welcome to ВИТРИНЫ.");
            Console.WriteLine("1. Посмотреть витрины");
            Console.WriteLine("2. Посмотреть товары в витрине");
            Console.WriteLine("3. Создать новую витрину.");
            Console.WriteLine("4. Отредактировать витрину.");
            Console.WriteLine("5. Удалить витрину.");
            Console.WriteLine("6. Добавить товар в витрину.");
            Console.WriteLine("---------------------------");
            Console.WriteLine("0. Выйти из программы.");
        }

        private static void CreateShopWindow()
        {

        }
    }
}
