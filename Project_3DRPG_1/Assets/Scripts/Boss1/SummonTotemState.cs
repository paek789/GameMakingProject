using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTotemState : StateMachineBehaviour
{
    Boss1 boss1;
    [SerializeField]
    GameObject totem;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        animator.SetBool("isSummonTotem", false);
        boss1.SummonTotemCoolTime = 40;
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Instantiate(totem, new Vector3(-20f,0.5f,0), Quaternion.identity);
        Instantiate(totem, new Vector3(20f, 0.5f, 0), Quaternion.identity);
        boss1.StartCoroutine("SummonTotemCoolDown");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
