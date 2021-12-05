using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover_Demon : StateMachineBehaviour
{
    Demon demon;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        demon.isCover = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isCover", false);
        demon.isCover = false;
    }
}
