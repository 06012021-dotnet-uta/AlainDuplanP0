using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0Context;
using Model;

namespace Businesss
{
    /// <summary>
    /// Helps Adding class add items
    /// </summary>
    public class AddingItem
    {
        ShopperContext context = new ShopperContext();

        /// <summary>
        /// Checks if input was an int and loops until valid input is given
        /// </summary>
        /// <param name="input">Input string from ReadLine</param>
        /// <returns>An int input</returns>
        private int isThisAnInt(string input)
        {
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion)
            {
                Console.WriteLine("ID is in the incorrect format, enter a new one");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
      
        private int storeSelect()
        {
            Console.WriteLine("Select a store to restock");
            int SId = isThisAnInt(Console.ReadLine());
            P0Context.Store storeC = context.Stores.Where(x => x.StoreId == SId).FirstOrDefault();
            if (storeC == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)");
                return storeSelect();
            }
            else
            {
                return SId;
            }
        }
        private int itemSelect()
        {
            Console.WriteLine("Select a item to restock");
            int SId = isThisAnInt(Console.ReadLine());
            P0Context.Item storeC = context.Items.Where(x => x.ItemId == SId).FirstOrDefault();
            if (storeC == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)");
                return storeSelect();
            }
            else
            {
                return SId;
            }
        }
        private int quantity(int s, int i)
        {
            Console.WriteLine("Select a quantity to restock");
            int SId = isThisAnInt(Console.ReadLine());
            
            P0Context.StoreInventory si = context.StoreInventories.Where(x => x.ItemId == i && x.StoreId == s).FirstOrDefault();
            if (si == null || si.Quantity == 0)
            {
                return SId;
            }
            else
                return SId + si.Quantity;
        }
        /// <summary>
        /// Adds new items to store inventory
        /// </summary>
        public void finalize()
        {
            int s = storeSelect();
            int i = itemSelect();
            int q = quantity(s, i);
            P0Context.StoreInventory si = context.StoreInventories.Where(x => x.ItemId == i && x.StoreId == s).FirstOrDefault();
            P0Context.StoreInventory newSi;
            if (si == null)
            {
                ShopperContext context1 = new ShopperContext();
                newSi = new P0Context.StoreInventory();
                newSi.ItemId = i;
                newSi.StoreId = s;
                newSi.Quantity = q;
                context1.StoreInventories.Add(newSi);
                context1.SaveChanges();
                Console.WriteLine($"Store{s} now has {q} of item #{i} in stock");
                return;
            }
            else
            {
                ShopperContext context2 = new ShopperContext();
                newSi = new P0Context.StoreInventory();
                newSi.ItemId = i;
                newSi.StoreId = s;
                newSi.Quantity = q;
                context2.StoreInventories.Attach(newSi);
                context2.Entry(newSi).Property(x => x.Quantity).IsModified = true;
                context2.SaveChanges();
                Console.WriteLine($"Store{s} now has {q} of item #{i} in stock");
                return;
            }

        }
    }
}
