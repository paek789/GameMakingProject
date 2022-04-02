using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_Demon : StateMachineBehaviour
{
    Demon demon;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        timer = 0;
        demon.speed *= 2;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);
        timer += Time.deltaTime;
        if (timer >0.35f && timer < 0.55f)
        {
            if (Vector3.Distance(demon.transform.position, demon.transform_Player.position) > 1.5f)
            {
                demon.transform.position = Vector3.MoveTowards(demon.transform.position, demon.transform_Player.position, Time.deltaTime * demon.speed);
            }
            demon.meleeAttack_range.enabled = true;
        }
        else
        {
            demon.meleeAttack_range.enabled = false;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.speed /= 2;
        animator.SetBool("isAttack", false);
    }
}
