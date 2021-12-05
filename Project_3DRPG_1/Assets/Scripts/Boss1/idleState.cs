using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    int randint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        randint = Random.Range(0,10);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(boss1Transform.position, boss1.player.position) < 25)
        {
            if (Vector3.Distance(boss1Transform.position, boss1.player.position) <= 6 && randint > 4 && boss1.a <= 0)
            {
                animator.SetBool("isRunaway", true);
            }
            else if (Vector3.Distance(boss1Transform.position, boss1.player.position) <= 6)
            {
                animator.SetBool("isWalk", true);
            }

            if (Vector3.Distance(boss1Transform.position, boss1.player.position) > 6 && randint > 5)
                animator.SetBool("isShout2", true);
            else if (Vector3.Distance(boss1Transform.position, boss1.player.position) > 6)
                animator.SetBool("isShout1", true);
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         
    }
}
