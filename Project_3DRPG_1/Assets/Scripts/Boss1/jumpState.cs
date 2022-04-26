using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpState : StateMachineBehaviour
{
    Transform boss1Transform;
    Transform cplayerTransform;
    Boss1 boss1;
    Rigidbody rigid;
    Material mat;
    MeshRenderer mesh;
    SphereCollider jumpAttack;
    CameraFollow camerafollow;
    float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();

        camerafollow = Camera.main.GetComponent<CameraFollow>();

        jumpAttack = GameObject.Find("JumpAttackRange").GetComponent<SphereCollider>();
        mat = GameObject.Find("JumpAttackRange").GetComponent<MeshRenderer>().material;
        mesh = GameObject.Find("JumpAttackRange").GetComponent<MeshRenderer>();

        rigid = boss1.GetComponent<Rigidbody>();
        cplayerTransform = boss1.player;
        boss1.speed *= 3;
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //boss1Transform.LookAt(boss1.player);
        boss1Transform.LookAt(cplayerTransform);

        timer += Time.deltaTime;

        if (timer > 0.5f && timer < 1f)
        {
            rigid.AddForce(Vector3.up, ForceMode.Impulse);
            if (Vector3.Distance(boss1.player.position, boss1Transform.position) > 3)
                boss1Transform.position = Vector3.MoveTowards(boss1Transform.position, cplayerTransform.position, Time.deltaTime * boss1.speed);
        }
        if (timer > 0.4f && timer < 1.05f)
        {
            mat.color = Color.blue;
            mesh.enabled = true;
        }
        else if (timer >= 1.05f && timer < 1.20f)
        {
            jumpAttack.enabled = true;
            camerafollow.StartCoroutine(camerafollow.Shake(0.5f, 0.15f));
            Debug.Log(animator.GetInteger("phase"));
            if (animator.GetInteger("phase") == 2)
            {
                boss1.StopCoroutine("DropMeteor");
                boss1.StartCoroutine("DropMeteor");
                Debug.Log("코루틴호출");
            }
        }
        else
        {
            mesh.enabled = false;
            jumpAttack.enabled = false;
        }


        animator.SetBool("isAttack3", true);

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1Transform.LookAt(boss1.player);
        animator.SetBool("isJump", false);
        boss1.speed /= 3;
        mesh.enabled = false;
        jumpAttack.enabled = false;
    }

}
