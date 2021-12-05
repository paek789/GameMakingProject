using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shout1State : StateMachineBehaviour
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
        animator.SetBool("isRun", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isShout1", false);

    }

}
