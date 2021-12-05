using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Demon : StateMachineBehaviour
{
    int randint;
    Demon demon;
    Vector3 vector;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        vector = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform.position + vector);
        demon.transform.position += vector * Time.deltaTime * demon.speed;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
