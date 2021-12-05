using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Demon : StateMachineBehaviour
{
    Demon demon;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        demon.speed *= 3;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);
        if (Vector3.Distance(demon.transform.position, demon.transform_Player.position) > 1.5f)
        {
            demon.transform.position = Vector3.MoveTowards(demon.transform.position, demon.transform_Player.position, Time.deltaTime * demon.speed);
        }
        else animator.SetBool("isAttack", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.speed /= 3;
        animator.SetBool("isRun", false);
    }
}
