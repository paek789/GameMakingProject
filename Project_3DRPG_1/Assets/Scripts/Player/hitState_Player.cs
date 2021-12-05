using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitState_Player : StateMachineBehaviour
{
    Player player;
    CapsuleCollider melee_Attack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        player.invincibility = true;
        melee_Attack = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        melee_Attack.enabled = false;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //timer += Time.deltaTime;
        //if (timer < 0.18f) player.invincibility = false;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.invincibility = false;
    }

}
