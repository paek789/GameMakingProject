using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabState : StateMachineBehaviour
{
    Transform grabTransform;
    Boss1 boss1;
    Player player;
    Text guideText;
    Image grabGaugeImage;
    ParticleSystem grabParticle;
    float grabGauge;


    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        grabParticle = GameObject.Find("energyBlast").GetComponent<ParticleSystem>();
        grabParticle.Play();
        player = GameObject.Find("Player").GetComponent<Player>();
        grabTransform = GameObject.Find("GrabLoc").GetComponent<Transform>();
        GameObject.Find("Canvas").transform.Find("GamePanel").transform.Find("GrabGauge").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Tutorial").gameObject.SetActive(true);
        guideText = GameObject.Find("TutorialText").GetComponent<Text>();
        guideText.text = "A D 를 연타하여 벗어나세요!";
        grabGaugeImage = GameObject.Find("GrabGauge_Front").GetComponentInChildren<Image>();
        boss1 = animator.GetComponent<Boss1>();
        boss1.GrabCoolTime = 25;
        timer = 0;
        grabGauge = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player.transform.position = Vector3.MoveTowards(player.transform.position, grabTransform.position, 10f * Time.deltaTime);
        player.SendMessage("Grabbed",true);
        if (player.transform.position == grabTransform.position)
        {
            timer += Time.deltaTime;
            if (player.aDown || player.dDown)
            {
                grabGauge += 0.04f;
                player.aDown = false;
                player.dDown = false;
            }
            grabGaugeImage.rectTransform.localScale = new Vector3(grabGauge, 1f, 1f);


            if (timer > 1.5f)
            {
                player.curhealth -= 5;
                timer = 0;
            }
        }
        if (grabGauge >= 1)
        {
            animator.SetBool("isGrab", false);
            GameObject.Find("Canvas").transform.Find("GamePanel").transform.Find("GrabGauge").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("Tutorial").gameObject.SetActive(false);
            grabParticle.Stop();
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.SendMessage("Grabbed", false);
        boss1.StartCoroutine("GrabCoolDown");
    }
}
