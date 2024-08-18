using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour
{
    public List<Item> items_to_choose_from;
    private Item item_chosen;
    private AIPath path;
    private AIDestinationSetter destination;
    GameObject go_to_here;
    private bool getting_item;
    private bool go_to_checkout;
    private bool go_home;
    private bool is_upset;
    // Start is called before the first frame update
    void Awake()
    {
        path = GetComponent<AIPath>();
        destination = GetComponent<AIDestinationSetter>();

        bool g = path.reachedDestination;

        int randItem = Random.Range(0, items_to_choose_from.Count);
        item_chosen = items_to_choose_from[randItem];

        getting_item = true;
        go_to_checkout = false;
        go_home = false;

        is_upset = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /*
    grab all of the instances of furniture
        if getting item
            find all furniture that store that item type
            get a random one of same type to go to and assign it to go_to_here object 
            check if not null
        else if going to checkout
            find all furniture of that furniture type
            find one with shortest queue
            
    */
    private void getDestination()
    {
        GameObject[] allfurniture = GameObject.FindGameObjectsWithTag("furniture");

        if (getting_item)
        {
            List<GameObject> correct_storages = new List<GameObject>();
            for (int i = 0; i < allfurniture.Length; i++)
            {
                if (allfurniture[i].GetComponent<Furniture_Data>().furniture.Furniture_storageType == item_chosen.Item_storageType)
                {
                    correct_storages.Add(allfurniture[i]);
                }
            }

            int randStorage = Random.Range(0, correct_storages.Count);
            if (correct_storages.Count > 0)
            {
                go_to_here = correct_storages[randStorage];
            }
        }
        else if (go_to_checkout)
        {
            List<GameObject> checkout_counters = new List<GameObject>();
            for (int i = 0; i < allfurniture.Length; i++)
            {
                if ((int) allfurniture[i].GetComponent<Furniture_Data>().furniture.Furniture_Type == 2)
                {
                    checkout_counters.Add(allfurniture[i]);
                }
            }

            if (checkout_counters.Count > 0)
            {
                GameObject shortest_line = checkout_counters[0];
                for (int i = 0; i < checkout_counters.Count; i++)
                {
                    if (shortest_line.GetComponent<Furniture_Data>().standing_lines.Count > checkout_counters[i].GetComponent<Furniture_Data>().standing_lines.Count)
                    {
                        shortest_line = checkout_counters[i];
                    }
                }
            }
        }
        else if (go_home)
        {
            //figure out this later
            Destroy(this.gameObject);
        }
    }
}
