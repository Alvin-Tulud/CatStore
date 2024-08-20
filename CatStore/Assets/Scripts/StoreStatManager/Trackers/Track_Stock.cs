using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackStock : MonoBehaviour
{
    private List<Item> stock_items = new List<Item>();
    private List<Sprite> stock_images = new List<Sprite>();
    private List<Image> stock_slots = new List<Image>();
    private List<TextMeshProUGUI> stock_count = new List<TextMeshProUGUI>();

    float currentTime;
    float maxTime = 0.2f;

    bool calledOnce;
    // Start is called before the first frame update
    void Awake()
    {
        currentTime = Time.fixedTime;
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

        if (Time.fixedTime - currentTime > maxTime)
        {
            currentTime = Time.fixedTime;
            
            setStockCounts();
        }
    }


    private void setStockCounts()
    {
        for (int i = 0; i < stock_items.Count; i++)
        {
            stock_count[i].text = StoreStats.store_Stock[stock_items[i]].ToString();
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
            //Debug.Log(i);
        }
    }
}
