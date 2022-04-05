using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    float timer;
    GameManager gameManager;
    public Text tutorial_text;
    public int beacon;
    public int goblin;
    public int trap;
    public int tutorial;
    int beaconMake;
    int goblinMake;
    public GameObject goblin_object;
    public GameObject beacon_object;
    public GameObject tutorial_clear;
    public ParticleSystem trap_particle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = 0;
        beacon = 0;
        goblin = 0;
        beaconMake = 0;
        goblinMake = 0;
        trap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStart == true)
        {            
            timer += Time.deltaTime;
            if(timer > 5f && goblinMake==0)
            {
                tutorial_text.text = "WASD로 조작해 비콘을 밟으세요! (" + beacon + "/" + "4)";
            }
            if(timer >5f && beaconMake == 0 && beacon == 0)
            {
                Instantiate(beacon_object, new Vector3(40f, 0.500001f, -138f), Quaternion.identity);
                beaconMake++;
            }
            else if(beaconMake == 1 && beacon == 1)
            {
                Instantiate(beacon_object, new Vector3(48f, 0.500001f, -138f), Quaternion.identity);
                beaconMake++;
            }
            else if(beaconMake == 2 && beacon == 2)
            {
                Instantiate(beacon_object, new Vector3(40f, 0.500001f, -145f), Quaternion.identity);
                beaconMake++;
            }
            else if (beaconMake == 3 && beacon == 3)
            {
                Instantiate(beacon_object, new Vector3(48f, 0.500001f, -145f), Quaternion.identity);
                beaconMake++;
            }
            if(beacon == 4 && goblinMake == 0)
            {
                goblinMake++;
                tutorial_text.text = "공격 - 좌클릭 / 방어 - 우클릭 / SPACE - 구르기";
                Time.timeScale = 0.1f;
                timer = 0;
                Instantiate(goblin_object, new Vector3(45f, 0.7f, -137f), Quaternion.identity);
            }
            else if(beacon == 4 && goblinMake == 1 && timer >0.3f)
            {
                goblinMake++;
                Time.timeScale = 1.2f;
            }
            else if(goblin == 1 && goblinMake == 2)
            {
                goblinMake++;
                trap_particle.Stop();
                tutorial_clear.SetActive(false);
                tutorial_text.text = "안개가 걷혔습니다. 전진하세요!";
            }
            if(trap == 1)
            {
                trap++;
                tutorial_text.text = "구르기로 함정을 피하며 진행하세요!";
            }
            if(tutorial == 1)
            {
                tutorial_text.text = "튜토리얼은 여기까지입니다. 모든적을 처치하며 진행하세요!";
                timer = 0;
                tutorial = 2;
            }
            else if(tutorial == 2 && timer > 5f)
            {
                tutorial_text.text = "";
                tutorial = 3;
            }
            
        }
    }
}
