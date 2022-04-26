using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    Material mat;
    MeshRenderer mesh;
    BoxCollider meleeAttack;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        meleeAttack = GameObject.Find("MeleeAttackRange").GetComponent<BoxCollider>();
        mat = GameObject.Find("MeleeAttackRange").GetComponent<MeshRenderer>().material;
        mesh = GameObject.Find("MeleeAttackRange").GetComponent<MeshRenderer>();        
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer < 1.56f)
        {
            mat.color = Color.red;
            mesh.enabled = true;
        }
        else   mesh.enabled = false;
        if ((timer >= 0.95f && timer <= 1.05f) || (timer >= 1.6f && timer <= 1.7f))
        {
            meleeAttack.enabled = true;
        }
        else
        {
            meleeAttack.enabled = false;
        }
            
        animator.SetBool("isAttack2", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meleeAttack.enabled = false;
        mesh.enabled = false;
    }

}
