using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeState : State
{
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    private GameObject go_to_here;

    private bool first_run;

    private void Awake()
    {
        first_run = true;
    }
    public override State RunCurrentState()
    {
        if(first_run)
        {
            getDestination();
            first_run = false;
        }
        //Debug.Log("i go home now: " + transform.name);
        if(go_to_here == null)
        {
            getDestination();
        }
        else
        {
            aiDestination.target = go_to_here.transform;
        }

        if (aiPath.reachedDestination)
        {
            Destroy(this.gameObject);
        }
        return this;
    }

    public override State getDestination()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("spawnpoint");
        int randpoint = Random.Range(0, points.Length);

        go_to_here = points[randpoint];
        return this;
    }
}
