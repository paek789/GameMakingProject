using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState_Player : StateMachineBehaviour
{
    Player player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.vDown || player.hDown) animator.SetBool("isWalk", true);
        else animator.SetBool("isWalk", false);

        if (player.mlDown)  animator.SetTrigger("doAttack");

        if (player.mrDown) animator.SetBool("isBlock", true);
        else animator.SetBool("isBlock", false);

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}