using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1_Demon : StateMachineBehaviour
{
    Demon demon;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        demon.StartCoroutine("Dospell1");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("spell1", false);
    }
}
