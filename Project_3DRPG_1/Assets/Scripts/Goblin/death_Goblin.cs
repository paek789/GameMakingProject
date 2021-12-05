using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_Goblin : StateMachineBehaviour
{
    float timer;
    CapsuleCollider meleeAttack_Goblin;
    Goblin goblin;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        goblin = animator.GetComponent<Goblin>();
        goblin.meleeAttack_Goblin.enabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(animator.gameObject);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
