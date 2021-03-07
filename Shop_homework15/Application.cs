using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15
{
    public class Application
    {
        private readonly IShopWindowController _shopWindowController;

        public Application(IShopWindowController shopWindowController)
        {
            _shopWindowController = shopWindowController;
        }

        public void Start()
        {
            do
            {
                Console.Clear();
                ShowMenu();
                int userChoice = GetUserInput();

                switch (userChoice)
                {
                    case 1:
                        ShowShopWindow();
                        break;
                    case 3:
                        CreateShopWindow();
                        break;
                    case 4:
                        EditShopWindow();
                        break;
                    case 5:
                        DeleteShopWindow();
                        break;
                    case 0:
                        return;
                }

            } while (true);
        }

        private int GetUserInput()
        {
            Console.WriteLine("Выбирите пункт меню: ");
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

        private void ShowMenu()
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

        private void CreateShopWindow()
        {
            Console.Clear();
            Console.WriteLine("3. Создать новую витрину.");
            //TODO: Проверка на ввод витрины
            Console.WriteLine("Введите имя витрины: ");
            string shopWindowName = Console.ReadLine();
            Console.WriteLine("Введите объем витрины: ");
            //TODO: Проверка на ввод объема витрины
            string shopWindowCapacity = Console.ReadLine();
            int capacity;
            bool isInt = Int32.TryParse(shopWindowCapacity, out capacity);

            _shopWindowController.CreateShopWindow(shopWindowName, capacity);
        }

        private void ShowShopWindow()
        {
            Console.Clear();
            Console.WriteLine("1. Посмотреть список созданных витрин");

            var shopWindows = _shopWindowController.GetShopWindows();

            foreach (var shopWindow in shopWindows)
            {
                Console.WriteLine($" ID: {shopWindow.ID} Name: {shopWindow.Name} Capacity: {shopWindow.Capacity}");
            }

            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
        }

        private void EditShopWindow()
        {
            //1. найти по имени витрину

            Console.WriteLine("Введи имя витрины для редактирования:");
            string shopWindowName = Console.ReadLine();

            ShopWindow shopWindowForEdit = _shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowForEdit == null)
                return;

            //2. отредактировать витрину
            Console.WriteLine("Введите новое имя для витрины:");
            string newName = Console.ReadLine();

            Console.WriteLine("Введите новый объем витрины: ");
            string shopWindowCapacity = Console.ReadLine();
            int newCapacity;
            bool isInt = Int32.TryParse(shopWindowCapacity, out newCapacity);

            _shopWindowController.EditShopWindow(shopWindowForEdit.ID, newName, newCapacity);
        }

        private void DeleteShopWindow()
        {
            Console.WriteLine("Введи имя витрины для удаления:");
            string shopWindowName = Console.ReadLine();

            ShopWindow shopWindowForDel = _shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowForDel == null)
                return;

            _shopWindowController.DeleteShopWindow(shopWindowForDel);
        }
    }
}
