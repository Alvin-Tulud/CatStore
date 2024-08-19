using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class GoCheckoutState : State
{
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    public GoHomeState homeState;
    private bool paid;

    private GameObject go_to_here = null;
    private GameObject line_up_behind = null;

    float currentTime;
    float checkoutTime = 3f;

    public override State RunCurrentState()
    {
        if (paid)
        {
            Debug.Log("done");
            return homeState;
        }
        else
        {
            //do logic for going to checkout
                //queues in checkout until it has its turn
                    //only check to dequeue it at checkout when it is near the checkout register it wants to go to
            if (go_to_here != null)
            {
                atCheckout();
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
        get the checkout with the shortest line to go to and assign it to go_to_here object 
        check if not null
    */
    public override State getDestination()
    {
        GameObject[] allfurniture = GameObject.FindGameObjectsWithTag("furniture");

        List<GameObject> checkout_counters = new List<GameObject>();
        for (int i = 0; i < allfurniture.Length; i++)
        {
            if ((int)allfurniture[i].GetComponent<Furniture_Data>().furniture.Furniture_Type == 2)
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

            go_to_here = shortest_line;
        }

        line_up_behind = go_to_here.GetComponent<Furniture_Data>().LineUp(gameObject);
        aiDestination.target = line_up_behind.transform;

        return this;
    }

    /*
    do a raycast to check how far away they are from the register
        if the raycast detects the register 0.6 units away
            if the npc is the first in line for the register
                make them path to the register
                check if they are close to the resgister
                    when they are dequeue them and add to happiness meter if not behind 5? people in line
    */
    private void atCheckout()
    {
        //Debug.DrawLine(transform.position, go_to_here.transform.position, Color.blue);
        //Debug.Log(transform.name + ": " + Vector3.Distance(transform.position, go_to_here.transform.position));
        if (go_to_here.GetComponent<Furniture_Data>().CheckIfFirstInLine(gameObject))
        {
            line_up_behind = go_to_here;
            aiDestination.target = line_up_behind.transform;
            //Debug.Log(transform.name + ": " + Vector3.Distance(transform.position, go_to_here.transform.position));
            //Debug.Log(line_up_behind.name);
            if (Vector3.Distance(transform.position, go_to_here.transform.position) <= 1.8f)
            {
                if (Time.time - currentTime > checkoutTime)
                {
                    //Debug.Log("at checkout");
                    //Debug.Log("bought");
                    go_to_here.GetComponent<Furniture_Data>().GetOutOfLine();
                    paid = true;
                }
            }
            else
            {
                currentTime = Time.fixedTime;
            }
        }
    }
}
