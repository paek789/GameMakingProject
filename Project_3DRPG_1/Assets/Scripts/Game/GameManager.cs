using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject cameraMain;
    public GameObject cameraMenu;
    public Player player;
    public Boss1 boss1;
    public float timer;
    public bool gameStart;
    public GameObject panelMenu;
    public GameObject panelGame;
    public GameObject statusMenu;
    public GameObject tutorial;
    public GameObject goblin1;
    public GameObject goblin2;
    public GameObject goblin3;
    public GameObject demon;
    public GameObject boss;


    public Text textBossHp;
    public Text textPlayerHp;
    public Text textTime;
    public Text player_damage;
    public Text player_speed;
    public Text player_health;
    public Text player_remainPoint;
    public Text player_remainPotion;
    public RectTransform healthBoss;
    public RectTransform healthPlayer;

    int remainPoint;
    public int remainPotion;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        remainPoint = 5;
        remainPotion = 3;
        Time.timeScale = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            statusMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            UsePotion();
        }
    }

    public void startGame()
    {
        gameStart = true;
        this.GetComponent<TutorialManager>().enabled = true;
        cameraMain.SetActive(true);
        panelGame.SetActive(true);
        cameraMenu.SetActive(false);
        panelMenu.SetActive(false);
        tutorial.SetActive(true);
        player.gameObject.SetActive(true);
        goblin1.SetActive(true);
        goblin2.SetActive(true);
        goblin3.SetActive(true);
        boss.SetActive(true);
        demon.SetActive(true);
    }

    private void LateUpdate()
    {
        textPlayerHp.text = player.curhealth + " / " + player.health;
        textBossHp.text = boss1.curHealth + " / " + boss1.maxHealth;
        textTime.text =((int)((timer % 3600) / 60)).ToString() + ":" + ((int)(timer % 60)).ToString();

        healthBoss.localScale = new Vector3((float)boss1.curHealth / (float)boss1.maxHealth, 1, 1);
        healthPlayer.localScale = new Vector3((float)player.curhealth / (float)player.health, 1, 1);
    }
    public void StatusMenuOff()
    {
        statusMenu.SetActive(false);
    }
    public void DamageClick()
    {
        if(remainPoint != 0)
        {
            player.damage += 1;
            remainPoint--;
            StatusUpdate();
        }
    }
    public void MovespeedClick()
    {
        if (remainPoint != 0)
        {
            player.speed += 0.4f;
            remainPoint--;
            StatusUpdate();
        }
    }
    public void HealthClick()
    {
        if (remainPoint != 0)
        {
            player.curhealth += 10;
            player.health += 10;
            remainPoint--;
            StatusUpdate();
        }
    }
    public void StatusUpdate()
    {
        player_remainPoint.text = "" + remainPoint;
        player_health.text = "" + player.health;
        player_damage.text = "" + player.damage;
        player_speed.text = "" + (float)(player.speed/4);
    }
    public void UsePotion()
    {
        if (remainPotion > 0)
        {
            player.Potionparticle();
            remainPotion--;
            player_remainPotion.text = "" + remainPotion;
            if (player.curhealth <= 70)
            {
                player.curhealth += 30;
                player.hpBar.rectTransform.localScale = new Vector3((float)player.curhealth / (float)player.health, 1f, 1f);
            }
            else
            {
                player.curhealth = player.health;
                player.hpBar.rectTransform.localScale = new Vector3((float)player.curhealth / (float)player.health, 1f, 1f);
            }

        }
    }

}
