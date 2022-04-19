using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState2_Player : StateMachineBehaviour
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
        GameObject.Find("Music").transform.Find("Player_Attack2").gameObject.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics.Raycast(ray, out hit))
        {
            clickPos = hit.point;
            clickPos.y = 0.5f;
        }

        player.transform.LookAt(clickPos);

        timer += Time.deltaTime;

        if (timer > 0.3f && timer < 0.5f) 
        {
            melee_Attack.enabled = true;
            player.transform.position += player.transform.forward * Time.deltaTime * player.speed * 2f;
        } 

        else melee_Attack.enabled = false;
        animator.SetBool("doAttack2", false);

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.rotateVec = player.transform.forward;
        GameObject.Find("Music").transform.Find("Player_Attack2").gameObject.SetActive(false);
    }

}
