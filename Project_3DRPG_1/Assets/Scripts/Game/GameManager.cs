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
    public GameObject goblin1;
    public GameObject goblin2;
    public GameObject goblin3;
    public GameObject demon;
    public GameObject boss;

    public Text textBossHp;
    public Text textPlayerHp;
    public Text textTime;
    public RectTransform healthBoss;
    public RectTransform healthPlayer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            timer += Time.deltaTime;
        }
    }

    public void startGame()
    {
        gameStart = true;
        cameraMain.SetActive(true);
        panelGame.SetActive(true);
        cameraMenu.SetActive(false);
        panelMenu.SetActive(false);
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
}
