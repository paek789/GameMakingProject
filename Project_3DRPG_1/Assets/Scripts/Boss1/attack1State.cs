using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1State : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    BoxCollider meleeAttack;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        meleeAttack = GameObject.Find("MeleeAttackRange").GetComponent<BoxCollider>();
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.94f && timer < 0.97f) meleeAttack.enabled = true;
        else meleeAttack.enabled = false;

        animator.SetBool("isAttack1", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meleeAttack.enabled = false;
    }

}
