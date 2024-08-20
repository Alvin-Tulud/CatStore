using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Track_Restock : MonoBehaviour
{
    private List<Item> stock_items = new List<Item>();
    private List<Sprite> stock_images = new List<Sprite>();
    private List<Image> stock_slots = new List<Image>();
    private List<TextMeshProUGUI> stock_count = new List<TextMeshProUGUI>();
    private List<int> stock_buy_counts = new List<int>();
    public Button buyButton;

    bool calledOnce;
    // Start is called before the first frame update
    void Awake()
    {
        calledOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!calledOnce)
        {
            setStats();
            calledOnce = true;
        }

        if (stock_buy_counts[0] * stock_items[0].Item_BuyValue +
            stock_buy_counts[1] * stock_items[1].Item_BuyValue +
            stock_buy_counts[2] * stock_items[2].Item_BuyValue +
            stock_buy_counts[3] * stock_items[3].Item_BuyValue +
            stock_buy_counts[4] * stock_items[4].Item_BuyValue +
            stock_buy_counts[5] * stock_items[5].Item_BuyValue > StoreStats.store_Money)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    private void setStats()
    {
        foreach (var item in StoreStats.getitemList())
        {
            stock_items.Add(item);
            stock_images.Add(item.Item_Image);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            stock_slots.Add(transform.GetChild(i).GetComponent<Image>());
            stock_slots[i].sprite = stock_images[i];
            stock_count.Add(transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>());
            stock_buy_counts.Add(0);
            stock_count[i].text = stock_buy_counts[i].ToString();
        }
    }

    public void addStock(int stock_index)
    {
        
        stock_buy_counts[stock_index]++;

        stock_count[stock_index].text = stock_buy_counts[stock_index].ToString();
    }

    public void subtractStock(int stock_index)
    {
        if (stock_buy_counts[stock_index] != 0)
        {
            stock_buy_counts[stock_index]--;
        }

        stock_count[stock_index].text = stock_buy_counts[stock_index].ToString();
    }

    public void buyStock()
    {
        
    }
}
