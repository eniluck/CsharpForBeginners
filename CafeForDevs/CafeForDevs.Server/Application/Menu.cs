﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeForDevs.Server.Application
{
    internal static class Menu
    {
        static Menu()
        {
            Items = new[]
            {
                new MenuItem()
                {
                    Id = 1,
                    Name = "Breakfast",
                    Price = 100
                },
                new MenuItem()
                {
                    Id = 2,
                    Name = "Lunch",
                    Price = 250
                },
                new MenuItem()
                {
                    Id = 3,
                    Name = "Dinner",
                    Price = 400
                }
            };
        }

        internal static MenuItem[] Items { get; private set; }

        internal static MenuItem Get(int menuItemId)
        {
            return Items.SingleOrDefault(x => x.Id == menuItemId);
        }
    }
}
