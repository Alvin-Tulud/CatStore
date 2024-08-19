using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : StateMachineBehaviour
{
    protected AIPath walking_speed_check;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        walking_speed_check = animator.transform.parent.GetComponent<AIPath>();
        //Debug.Log(animator.transform.parent.name + ": " + walking_speed_check.velocity);

        if (walking_speed_check.velocity != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
