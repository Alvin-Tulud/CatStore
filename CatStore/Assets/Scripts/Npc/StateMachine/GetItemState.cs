using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemState : State
{
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    public GoCheckoutState checkoutState;
    public GoHomeState homeState;
    public SpriteRenderer thought;
    private bool got_Item;
    private bool cant_get_Item;

    public List<Item> items_to_choose_from;
    private Item item_chosen;
    private GameObject go_to_here = null;

    float currentTime;
    float maxTime = 0.5f;

    private void Awake()
    {
        int randItem = Random.Range(0, items_to_choose_from.Count);
        item_chosen = items_to_choose_from[randItem];

        thought.sprite = item_chosen.Item_Image;

        currentTime = Time.fixedTime;

        got_Item = false;
        cant_get_Item = false;
    }

    //treat as if it were an update function
    public override State RunCurrentState()
    {
        if (got_Item)
        {
            return checkoutState;
        }
        else if (cant_get_Item)
        {
            return homeState;
        }
        else
        {
            //do logic for getting item
                //goes to item until it reaches the stand it wants to go to
            if (go_to_here != null)
            {
                aiDestination.target = go_to_here.transform;
                findShelf();
            }
            else
            {
                getDestination();
            }

            return this;
        }
    }

    /*
    grab all of the instances of furniture
        find all furniture that store that item type
        get a random one of same type to go to and assign it to go_to_here object 
        check if not null
    */
    public override State getDestination()
    {
        //Debug.Log("finding: " + item_chosen.Item_Name);
        GameObject[] allfurniture = GameObject.FindGameObjectsWithTag("furniture");

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

        return this;
    }

    /*
    do a raycast to check how far away they are from the shelf
        shoot raycast every 0.5s or something
        if the raycast detects the shelf 0.6 units away
            check if the item is in stock
                if it is call the function from store stats to take the item from inventory
                else flip bool to go home and take away 1 happiness point
    */
    private void findShelf()
    {
        if (Time.fixedTime - currentTime > maxTime)
        {
            //Debug.Log("check 0.5s");
            currentTime = Time.fixedTime;

            if (aiPath.reachedEndOfPath)
            {
                //Debug.Log("path done");
                if (StoreStats.Grab_Stock(item_chosen))
                {
                    //Debug.Log("took: " + item_chosen.Item_Name);
                    thought.sprite = item_chosen.Buy_Image;
                    got_Item = true;
                }
                else
                {
                    //Debug.Log("theres no: " + item_chosen.Item_Name);
                    thought.sprite = item_chosen.Angy_Image;
                    StoreStats.Subtract_Happiness();
                    cant_get_Item = true;
                }
            }
        }
    }

    public Item getItemChosen() { return item_chosen; }
}
