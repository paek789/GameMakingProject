using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2_Demon : StateMachineBehaviour
{
    Demon demon;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        GameObject intantSpell1 = Instantiate(demon.spell2, demon.transform_Player.position, demon.transform.rotation);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("spell2", false);
    }
}
