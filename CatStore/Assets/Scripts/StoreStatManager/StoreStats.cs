using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStats : MonoBehaviour
{
    public static StoreStats store_stats;

    public int store_happiness;
    public int store_Money;

    public List<Item> store_Items;


    public Dictionary<Item, int> store_Stock = new Dictionary<Item, int>();

    void Awake()
    {
        if (store_stats != null)
            GameObject.Destroy(store_stats);
        else
            store_stats = this;

        DontDestroyOnLoad(this);

        for (int i = 0; i < store_Items.Count; i++)
        {
            store_Stock.Add(store_Items[i], 0);
        }
    }


    //called by restock menu
    //returns false when player cannot buy the amount of stock they specified
    //returns true otherwise
    public bool Buy_Stock(Item item, int amount) 
    {
        if (item.Item_BuyValue * amount > store_Money)
        {
            return false;
        }
        else
        {
            store_Stock[item] += amount;
        }
        return true;
    }
    
    //called by npc at cashier
    public void Sell_Stock(Item item)
    {
        store_Money += item.Item_SellValue;
    }

    //called by self to see if item has stock
    //returns false when there is no stock
    //returns true otherwise
    public bool Check_Stock(Item item)
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
    public bool Grab_Stock(Item item)
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
    public void Add_Happiness()
    {
        if (store_happiness < 100)
        {
            store_happiness++;
        }
    }


    //called by npc once if they cant find the item they want
    //called by the npc of they wait too long in a checkout line
        //wont call add_Happiness during checkout if they took too long to checkout
    public void Subtract_Happiness()
    {
        if (store_happiness > 0)
        {
            store_happiness--;
        }
    }
}
