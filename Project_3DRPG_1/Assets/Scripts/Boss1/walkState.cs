using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1Transform.LookAt(boss1.player);

        if (Vector3.Distance(boss1.player.position, boss1Transform.position) > 3 && Vector3.Distance(boss1.player.position, boss1Transform.position) <= 7)
        {
            boss1Transform.position = Vector3.MoveTowards(boss1Transform.position, boss1.player.position, Time.deltaTime * boss1.speed);
            
        }
        else if (Vector3.Distance(boss1.player.position, boss1Transform.position) > 7)
            animator.SetBool("isWalk", false);
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isAttack1", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
