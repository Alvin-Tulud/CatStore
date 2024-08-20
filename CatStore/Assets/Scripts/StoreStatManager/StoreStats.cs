using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStats : MonoBehaviour
{
    public static int store_happiness;
    public static int store_Money;

    public List<Item> store_Items;
    public static List<Item> store_Items_copy = new List<Item>();


    public static Dictionary<Item, int> store_Stock = new Dictionary<Item, int>();

    void Awake()
    {
        store_happiness = 100;
        store_Money = 500;

        for (int i = 0; i < store_Items.Count; i++)
        {
            store_Stock.Add(store_Items[i], 10);
        }

        store_Items_copy = store_Items;
    }


    //called by restock menu
    //returns false when player cannot buy the amount of stock they specified
    //returns true otherwise
    public static bool Buy_Stock(Item item, int amount) 
    {
        if (item.Item_BuyValue * amount > store_Money)
        {
            return false;
        }
        else
        {
            store_Stock[item] += amount;
            store_Money -= item.Item_BuyValue * amount;
        }
        return true;
    }

    //called by npc at cashier
    public static void Sell_Stock(Item item)
    {
        store_Money += item.Item_SellValue;
    }

    //called by self to see if item has stock
    //returns false when there is no stock
    //returns true otherwise
    public static bool Check_Stock(Item item)
    {
        if (store_Stock[item] == 0)
        {
            return false;
        }
        return true;
    }

    //called by npc when they grab item at the shelf
    //if the item is in stock they will subtract it from the store stock
    //returns false if the store has none of that item left
    //returns true otherwise
    public static bool Grab_Stock(Item item)
    {
        if (!Check_Stock(item))
        {
            return false;
        }
        else
        {
            store_Stock[item]--;
        }
        return true;
    }

    //called by npc once when they checkout
    public static void Add_Happiness()
    {
        if (store_happiness < 100)
        {
            store_happiness++;
        }
    }


    //called by npc once if they cant find the item they want
    //called by the npc of they wait too long in a checkout line
    //wont call add_Happiness during checkout if they took too long to checkout
    public static void Subtract_Happiness()
    {
        if (store_happiness > 0)
        {
            store_happiness--;
        }
    }

    public static List<Item> getitemList() { return store_Items_copy; }
}
