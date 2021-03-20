using System;
using System.Collections.Generic;

namespace EventsAndExtensions
{
    // Делегат - тип данных
    public delegate void Notify(string message);

    internal class Program
    {
        //событие при запуске которого происходит вызов подписчиков делегата
        internal static event Notify OnAction;
        // event - тип данных. поле или свойство

        private static void Main(string[] args)
        {
            var cart = new Cart();
            /*cart.AfterItemAdded += Print;
             cart.AfterItemAdded += Info;
             cart.OnItemAdding += Print;
             cart.OnItemAdding += Info;*/
             cart.BeforeItemAdd += Print;
            cart.BeforeItemAdd += Info;

            cart.AddItem("Test item");
        }

        private static void SetAndInvokeEvent()
        {
            OnAction = Print;

            if (OnAction != null)
                OnAction.Invoke("Hello World");
            else
                Console.WriteLine($"Event {nameof(OnAction)} cannot be null");
        }

        private static void Print(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }

    // Некоторый тестовый класс 
    public class Cart  
    {
        private List<string> _items;

        public Cart()
        {
            _items = new List<string>();
            _notifies = new List<Notify>();
        }

        private List<Notify> _notifies;

        public event Notify BeforeItemAdd
        {
            add {
                _notifies.Add(value);
                Console.WriteLine("BeforeItemAdd added ");
            
            }
            remove {
                _notifies.Remove(value);
                Console.WriteLine("BeforeItemAdd deleted");

            }
        }

        public event Notify OnItemAdding;
        public event Notify AfterItemAdded;

        public virtual void AddItem(string item)
        {
            foreach (var notify in _notifies)
            {
                notify.Invoke(""+item);
            }

            //BeforeItemAdd?.Invoke("BeforeItemAdd " + item);

            if (string.IsNullOrEmpty(item))
                throw new ArgumentException(nameof(item));

            OnItemAdding?.Invoke("OnItemAdding " + item);
            _items.Add(item);

            AfterItemAdded?.Invoke("AfterItemAdded " + item);
        }

        /*
        public void OnItemAdding(object sender, string message)
        {

        }*/

    }

    

    public class SmartCart : Cart
     {
         public override void AddItem(string item)
         {
             if (string.IsNullOrEmpty(item))
                 throw new ArgumentException(nameof(item));
             /*
             OnItemAdding?.Invoke("OnItemAdding " + item);
             _items.Add(item);

             AfterItemAdded?.Invoke("AfterItemAdded " + item);
             */
         }
     }
}
