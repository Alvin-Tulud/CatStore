using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Furniture_Data : MonoBehaviour
{
    public Furniture furniture;
    public Queue<GameObject> standing_lines = new Queue<GameObject>();
    GameObject last_in_line;

    //lines up the npcs behind eachother as they pathfind to eachother and stop around them forming lines
        //returns the game objects that the npc should follow
            //if theres nothing in the queue it will navigate to the checkout
            //else navigate to the last npc in the line
    public GameObject LineUp(GameObject self)
    {
        if (standing_lines.Count == 0)
        {
            standing_lines.Enqueue(self);
            last_in_line = self;

            return this.gameObject;
        }
        else
        {
            GameObject prev_last_in_line = last_in_line;
            standing_lines.Enqueue(self);
            last_in_line = self;

            return prev_last_in_line;
        }
    }


    //checks if the first npc in line is at the register
    public bool CheckIfFirstInLine(GameObject self)
    {
        if (standing_lines.Count > 0 && self.GetInstanceID() == standing_lines.Peek().GetInstanceID())
        {
            //Debug.Log("first: " + self.name);
            return true;
        }
        //Debug.Log("not first: " + self.name);
        return false;
    }

    //called when the npc should be taken out of the queue
    public void GetOutOfLine()
    {
        standing_lines.Dequeue();
    }
}
