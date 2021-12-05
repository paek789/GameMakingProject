using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_Goblin : StateMachineBehaviour
{
    public GameObject arrow;
    Goblin goblin;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblin = animator.GetComponent<Goblin>();
        goblin.transform.LookAt(goblin.transform_Player);
        goblin.StartCoroutine("arrowShot");
        
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack_goblin", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
