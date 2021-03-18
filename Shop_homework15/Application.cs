using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;

namespace Shop_homework15
{
    public class Application
    {
        private readonly IShopWindowController _shopWindowController;
        private readonly IProductController _productController;

        public Application(IShopWindowController shopWindowController, IProductController productController)
        {
            _shopWindowController = shopWindowController;
            this._productController = productController;
        }

        public void Start()
        {
            do
            {
                Console.Clear();
                ShowMenu();
                int userChoice = GetMenuNumber();

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
                    case 6:
                        ShowShopWindowProducts();
                        break;
                    case 7:
                        AddProductoToShopWindow();
                        break;
                    case 9:
                        ShowProducts();
                        break;
                    case 10:
                        CreateProduct();
                        break;
                    case 0:
                        return;
                }

            } while (true);
        }

        private void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("Список всех продуктов:");
            foreach (var product in _productController.GetProducts())
            {
                Console.WriteLine(product.GetInfo());
            }
            
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }

        private void CreateProduct()
        {
            string name = GetStringFromUser("Введите имя товара: ");
            int size = GetIntFromUser("Введите резмер товара:");

            _productController.CreateProduct(name, size);
        }

        private void ShowShopWindowProducts()
        {
            foreach (var shopWindow in _shopWindowController.GetShopWindows())
            {
                Console.WriteLine(shopWindow.Name);

                foreach (var shopWindowProduct in _shopWindowController.GetShopWindowProducts(shopWindow.ID))
                {
                    Product product = _productController.GetProductByID(shopWindowProduct.ProductID);
                    Console.WriteLine(product.Name);
                }
            } 
        }

        private void AddProductoToShopWindow()
        {
            //Найти витрину по имени.
            string shopWindowName = GetStringFromUser("Введи имя витрины для добавления товара:");
            ShopWindow shopWindowFound = _shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowFound == null)
                return;

            //Найти товар по имени.
            string productName = GetStringFromUser("Введи имя товара который будет помещён на витрину:");
            Product productFound = _productController.GetProductByName(productName);

            if (productFound == null)
                return;

            //Спросить стоимость и количество 
            int productCost = GetIntFromUser("Укажите стоимость товара.");
            int productQuantity = GetIntFromUser("Укажите количество товара.");


            //Добавить товар в витрину.
            _shopWindowController.AddProduct(shopWindowFound.ID, productFound.ID, productCost, productQuantity);
        }

        private void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в программу управления Витринами.");
            Console.WriteLine("------- Витрины -------");
            Console.WriteLine("1. Посмотреть список созданных витрин");
            Console.WriteLine("2. Посмотреть список товаров в витрине");
            Console.WriteLine("3. Создать новую витрину.");
            Console.WriteLine("4. Отредактировать витрину.");
            Console.WriteLine("5. Удалить витрину.");
            Console.WriteLine("------- Товары на витрине. -------");
            Console.WriteLine("6. Посмотреть товары на витрине.");
            Console.WriteLine("7. Добавить товар в витрину.");
            Console.WriteLine("8. Убрать товар с витрины.");
            Console.WriteLine("------- Товары -------");
            Console.WriteLine("9. Просмотреть список товаров");
            Console.WriteLine("10. Создать товар");
            Console.WriteLine("11. Редактировать товар");
            Console.WriteLine("12. Удалить товар");
            Console.WriteLine("---------------------------");
            Console.WriteLine("0. Выйти из программы.");
        }

        private int GetMenuNumber()
        {
            int menuItem;
            do
            {
                menuItem = GetIntFromUser("Выбирите пункт меню: ");
            } while (menuItem < 0 || menuItem > 13);

            return menuItem;
        }

        private int GetIntFromUser(string message)
        {
            Console.WriteLine("Введите целое число.");
            Console.WriteLine(message);
            string userInput;
            bool isInt;
            int intValue;
            do
            {
                userInput = Console.ReadLine();
                isInt = Int32.TryParse(userInput, out intValue);
                if (isInt == false)
                    Console.WriteLine("Вы ввели не целое число. Повторите ввод.");
            } while ( isInt == false );
            return intValue;
        }

        private string GetStringFromUser(string message)
        {
            Console.WriteLine("Введите не пустую строку.");
            Console.WriteLine(message);
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput) == true)
                    Console.WriteLine("Вы ввели пустую строку. Повторите ввод.");

            } while (string.IsNullOrWhiteSpace(userInput) == true);

            return userInput;
        }

        private void CreateShopWindow()
        {
            Console.Clear();
            Console.WriteLine("3. Создать новую витрину.");
            string shopWindowName = GetStringFromUser("Введите имя витрины: ");
            int capacity = GetIntFromUser("Введите объем витрины: ");
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

            string shopWindowName = GetStringFromUser("Введи имя витрины для редактирования:");

            ShopWindow shopWindowForEdit = _shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowForEdit == null)
                return;

            //2. отредактировать витрину
            string newName = GetStringFromUser("Введите новое имя для витрины:");

            int newCapacity = GetIntFromUser("Введите новый объем витрины: ");
            _shopWindowController.EditShopWindow(shopWindowForEdit.ID, newName, newCapacity);
        }

        private void DeleteShopWindow()
        {
            string shopWindowName = GetStringFromUser("Введите имя витрины для удаления:");
            ShopWindow shopWindowToDelete = _shopWindowController.GetShopWindowByName(shopWindowName);

            if (shopWindowToDelete == null)
                return;

            _shopWindowController.DeleteShopWindow(shopWindowToDelete.ID);
        }
    }
}
