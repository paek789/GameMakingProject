using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_Goblin : StateMachineBehaviour
{
    Transform transform_Player;
    int randint;
    Goblin goblin;
    Vector3 vector;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randint = Random.Range(1, 500);
        transform_Player = GameObject.Find("Player").transform;
        goblin = animator.GetComponent<Goblin>();
        vector = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("onFight_goblin"))
        {
            animator.SetInteger("isIdle_goblin", randint % 3 + 1);
        }
        else if (animator.GetBool("onFight_goblin"))
        {
            if (Vector3.Distance(goblin.transform.position, transform_Player.position) < 3)
            {
                animator.SetInteger("isClose_goblin", randint % 2);
            }
            else animator.SetBool("isAttack_goblin", true);
        }
        goblin.transform.position += vector * Time.deltaTime * goblin.speed;
        goblin.transform.LookAt(goblin.transform.position + vector);
        

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
