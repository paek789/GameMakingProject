using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runState : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        boss1.speed *= 3;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1Transform.LookAt(boss1.player);
        if (Vector3.Distance(boss1.player.position, boss1Transform.position) > 3)
            boss1Transform.position = Vector3.MoveTowards(boss1Transform.position, boss1.player.position, Time.deltaTime * boss1.speed);
        else
            animator.SetBool("isAttack2", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1.speed /= 3;
        animator.SetBool("isRun", false);
    }

}
