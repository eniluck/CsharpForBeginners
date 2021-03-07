using Shop_homework15.Models;
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
            ShopWindowController shopWindowController = new ShopWindowController();


            do
            {
                Console.Clear();
                ShowMenu();
                int userChoice = GetUserInput();

                switch (userChoice)
                {
                    case 1:
                        ShowShopWindow(shopWindowController);
                        break;
                    case 3:
                        CreateShopWindow(shopWindowController);
                        break;
                    case 4:
                        EditShopWindow(shopWindowController);
                        break;
                    case 5:
                        DeleteShopWindow(shopWindowController);
                        break;
                    case 0:
                        return;
                }

            } while (true);
        }

        private static int GetUserInput()
        {
            Console.WriteLine("Выбирай пункт меню: ");
            string userInput;
            bool isInt;
            int menuItem;
            do
            {
                userInput = Console.ReadLine();
                isInt = Int32.TryParse(userInput, out menuItem);

            } while (
                    (menuItem < 0 || menuItem > 6)
                    || isInt == false
            );
            return menuItem;
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Welcome to ВИТРИНЫ.");
            Console.WriteLine("1. Посмотреть список созданных витрин");
            Console.WriteLine("2. Посмотреть список товаров в витрине");
            Console.WriteLine("3. Создать новую витрину.");
            Console.WriteLine("4. Отредактировать витрину.");
            Console.WriteLine("5. Удалить витрину.");
            Console.WriteLine("6. Добавить товар в витрину.");
            Console.WriteLine("---------------------------");
            Console.WriteLine("0. Выйти из программы.");
        }

        //3. Создать новую витрину.
        private static void CreateShopWindow(ShopWindowController shopWindowController)
        {
            Console.Clear();
            Console.WriteLine("3. Создать новую витрину.");
            Console.WriteLine("Введите имя витрины: ");
            string shopWindowName = Console.ReadLine();
            Console.WriteLine("Введите объем витрины: ");
            string shopWindowCapacity = Console.ReadLine();
            int capacity;
            bool isInt = Int32.TryParse(shopWindowCapacity, out capacity);

            shopWindowController.CreateShopWindow(shopWindowName, capacity);
        }

        //1. Посмотреть список созданных витрин
        private static void ShowShopWindow(ShopWindowController shopWindowController)
        {
            Console.Clear();
            Console.WriteLine("1. Посмотреть список созданных витрин");

            var shopWindows = shopWindowController.GetShopWindows();

            foreach (var shopWindow in shopWindows)
            {
                Console.WriteLine($" ID: {shopWindow.ID} Name: {shopWindow.Name} Capacity: {shopWindow.Capacity}");
            }

            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
        }

        // 4. Отредактировать витрину
        private static void EditShopWindow(ShopWindowController shopWindowController)
        {
            //1. найти по имени витрину

            Console.WriteLine("Введи имя витрины для редактирования:");
            string shopWindowName = Console.ReadLine();

            ShopWindow shopWindowForEdit = shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowForEdit == null)
                return;

            //2. отредактировать витрину
            Console.WriteLine("Введите новое имя для витрины:");
            string newName = Console.ReadLine();

            Console.WriteLine("Введите новый объем витрины: ");
            string shopWindowCapacity = Console.ReadLine();
            int newCapacity;
            bool isInt = Int32.TryParse(shopWindowCapacity, out newCapacity);

            shopWindowController.EditShopWindow(shopWindowForEdit.ID, newName, newCapacity);
        }

        


        //5. Удалить витрину.
        private static void DeleteShopWindow(ShopWindowController shopWindowController)
        {
            Console.WriteLine("Введи имя витрины для удаления:");
            string shopWindowName = Console.ReadLine();

            ShopWindow shopWindowForDel = shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowForDel == null)
                return;

            shopWindowController.DeleteShopWindow(shopWindowForDel);

        }
    }
}
