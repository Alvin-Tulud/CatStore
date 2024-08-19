using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeState : State
{
    public AIPath aiPath;
    public AIDestinationSetter aiDestination;
    public override State RunCurrentState()
    {
        //Debug.Log("i go home now: " + transform.name);
        return this;
    }

    public override State getDestination()
    {
        throw new System.NotImplementedException();
    }
}
