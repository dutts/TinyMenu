using System;
using System.Collections.Generic;
using System.Text;

namespace TinyMenu
{
    public class TinyMenu
    {
        internal struct Item
        {
            internal string Desc { get; }
            internal Action Act { get; }

            public Item(string desc, Action act)
            {
                Desc = desc;
                Act = act;
            }
        }

        internal IList<Item> Items;
        internal string Name;

        internal TinyMenu(string name = null)
        {
            Name = name;
            Items = new List<Item>();
        }

        internal TinyMenu(IList<Item> items, string name = null)
        {
            Name = name;
            Items = items;
        }

        public void Show()
        {
            ConsoleKeyInfo k;
            do
            {
                Console.Clear();
                var sb = new StringBuilder();
                if (Name != null) sb.AppendLine("*** " + Name + " ****");
                for (int i = 0; i < Items.Count; i++)
                {
                    sb.AppendFormat("{0} - {1}{2}", i, Items[i].Desc, Environment.NewLine);
                }
                sb.AppendFormat("{0}q - Quit", Environment.NewLine);
                Console.WriteLine(sb.ToString());

                k = Console.ReadKey(true);

                if (Char.IsNumber(k.KeyChar) && Convert.ToInt32(k.KeyChar.ToString()) < Items.Count)
                {
                    Items[Convert.ToInt32(k.KeyChar.ToString())].Act.Invoke();
                }
            }
            while (k.Key != ConsoleKey.Q);
        }
    }

    public static class Tiny
    {
        public static TinyMenu Menu(string name = null)
        {
            return new TinyMenu(name);
        }

        public static TinyMenu _(this TinyMenu menu, string desc, Action act)
        {
            var existingMenuItems = menu.Items;
            existingMenuItems.Add(new TinyMenu.Item(desc, act));
            return new TinyMenu(existingMenuItems, menu.Name);
        }

        public static TinyMenu _(this TinyMenu menu, TinyMenu subMenu)
        {
            return menu._(subMenu.Name, () => subMenu.Show());
        }
    }
}
