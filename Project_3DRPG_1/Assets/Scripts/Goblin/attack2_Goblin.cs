using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2_Goblin : StateMachineBehaviour
{
    Transform transform;
    Goblin goblin;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblin = animator.GetComponent<Goblin>();
        transform = animator.GetComponent<Transform>();
        goblin.transform.LookAt(goblin.transform_Player);
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.6f && timer < 0.8f) goblin.meleeAttack_Goblin.enabled = true;
        else goblin.meleeAttack_Goblin.enabled = false;
        animator.SetInteger("isClose_goblin", 0);


    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
