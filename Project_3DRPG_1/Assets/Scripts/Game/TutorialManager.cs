using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public enum States
    {
        Movetutorial,
        Fighttutorial,
        Traptutorial
    }

    States state;

    public Text tutorial_text;
    public int beacon;
    public int goblin_die;
    public GameObject goblin_object;
    public GameObject beacon_object;
    public GameObject tutorial_clear;
    public ParticleSystem trap_particle;
    // Start is called before the first frame update
    void Start()
    {
        StateUpdate(States.Movetutorial);
        beacon = 0;
        goblin_die = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TutorialUpdate()
    {
        StateUpdate(state);
    }
    void StateUpdate(States _state)
    {
        state = _state;
        switch (state)
        {
            case States.Movetutorial:
                StartCoroutine("Moveroutine");
                break;
            case States.Fighttutorial:
                if (goblin_die == 1) 
                {
                    StateUpdate(States.Traptutorial);
                    break;
                }
                CreateGoblin();
                break;
            case States.Traptutorial:
                StartCoroutine("Traproutine");
                break;
        }
    }
    public void CreateGoblin()
    {
        tutorial_text.text = "공격 - 좌클릭 / 방어 - 우클릭 / SPACE - 구르기";
        GameObject tutorial_goblin = Instantiate(goblin_object, new Vector3(45f, 0.7f, -137f), Quaternion.identity);
        tutorial_goblin.SetActive(true);
    }
    public void CreateBeacon()
    {
        tutorial_text.text = "WASD로 조작해 비콘을 밟으세요! (" + beacon + "/" + "4)";
        switch (beacon)
        {
            case 0:
                Instantiate(beacon_object, new Vector3(40f, 0.500001f, -138f), Quaternion.identity);
                break;
            case 1:
                Instantiate(beacon_object, new Vector3(48f, 0.500001f, -138f), Quaternion.identity);
                break;
            case 2:
                Instantiate(beacon_object, new Vector3(40f, 0.500001f, -145f), Quaternion.identity);
                break;
            case 3:
                Instantiate(beacon_object, new Vector3(48f, 0.500001f, -145f), Quaternion.identity);
                break;
            case 4:
                StateUpdate(States.Fighttutorial);
                break;
        }
    }
    IEnumerator Moveroutine()
    {
        if (beacon == 0)
        {
            yield return new WaitForSeconds(5);
            tutorial_text.text = "WASD로 조작해 비콘을 밟으세요! (" + beacon + "/" + "4)";
        }
        CreateBeacon();
    }
    IEnumerator Traproutine()
    {
        trap_particle.Stop();
        tutorial_clear.SetActive(false);
        tutorial_text.text = "안개가 걷혔습니다. 전진하세요!";
        yield return new WaitForSeconds(3);
        tutorial_text.text = "이앞은 함정입니다. 구르기를 활용하여 진행하세요!";
    }
}
