using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();

    public abstract State getDestination();
}
