using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeState : State
{
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    private GameObject go_to_here;
    public override State RunCurrentState()
    {
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
