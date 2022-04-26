using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathState : StateMachineBehaviour
{    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("MeleeAttackRange").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("MeleeAttackRange2").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("JumpAttackRange").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("MeleeAttackRange").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("MeleeAttackRange2").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("JumpAttackRange").GetComponent<SphereCollider>().enabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("phase") == 2) Destroy(animator.gameObject, 3f);
        else
        {
            Boss1 boss1 = GameObject.Find("Boss1").GetComponent<Boss1>();
            boss1.curHealth = 300;
            animator.SetInteger("phase", 2);
            animator.SetBool("isDead", false);
            boss1.mat.color = Color.black;
            boss1.curColor = boss1.mat.color;
        }
    }
}
