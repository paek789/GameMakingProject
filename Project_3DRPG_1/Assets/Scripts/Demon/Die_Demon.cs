using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Demon : StateMachineBehaviour
{
    float timer;
    Demon demon;
    public GameObject item;
    Transform transform_item;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        demon = animator.GetComponent<Demon>();        
        demon.meleeAttack_range.enabled = false;

        GameObject intantitem = Instantiate(item, demon.transform.position, demon.transform.rotation);
        Rigidbody itemRigid = intantitem.GetComponent<Rigidbody>();
        itemRigid.velocity = demon.transform.forward * 10;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(animator.gameObject);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
