using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState_Player : StateMachineBehaviour
{
    Transform playertransform;
    Player player;
    CapsuleCollider melee_Attack;
    Vector3 clickPos;
    RaycastHit hit;
    Ray ray;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        playertransform = animator.GetComponent<Transform>();
        melee_Attack = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        timer = 0;
        clickPos = Vector3.one;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Physics.Raycast(ray, out hit))
        {
            clickPos = hit.point;
            clickPos.y = 0.5f;
        }

        player.transform.LookAt(clickPos);

        timer += Time.deltaTime;
        if (timer > 0.22f && timer < 0.42f) melee_Attack.enabled = true;
        else melee_Attack.enabled = false;
        if (timer > 0.10f && player.mlDown) animator.SetBool("doAttack2",true);

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.rotateVec = player.transform.forward;
    }

}
