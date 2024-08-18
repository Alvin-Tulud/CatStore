using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture_Data : MonoBehaviour
{
    public Furniture furniture;
    public List<GameObject> standing_lines = new List<GameObject>();
    GameObject last_in_line;

    private void Awake()
    {
        
    }
    private void Update()
    {
        //dequeue npcs at a set interval
    }

    //lines up the npcs behind eachother as they pathfind to eachother and stop around them forming lines
    public GameObject LineUp(GameObject self)
    {
        if (standing_lines.Count == 0)
        {
            standing_lines.Add(self);
            last_in_line = self;

            return this.gameObject;
        }
        else
        {
            GameObject prev_last_in_line = last_in_line;
            standing_lines.Add(self);
            last_in_line = self;

            return prev_last_in_line;
        }
    }
}
