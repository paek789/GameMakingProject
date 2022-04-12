using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Demon : MonoBehaviour
{
    public Transform transform_Player;
    public Transform spell1_Start;
    public GameObject spell1;
    public GameObject spell2;
    public float speed;
    public int damage;
    public int maxHealth;
    public int curHealth;
    public ParticleSystem hit;
    bool stiff;
    bool immune;
    public bool isCover;
    public BoxCollider meleeAttack_range;

    public GameObject hpBarpref;
    public GameObject hpbar_position;
    GameObject hpBar_parent;
    GameObject hpBar;
    HpBar hpBar_script;

    Player player;

    Animator animator;
    public SkinnedMeshRenderer skin;
    public ParticleSystem blockParticle;
    Material mat;
    Material curmat;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        transform_Player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        mat = skin.material;
        curmat = mat;
        immune = false;
        stiff = true;
        hpBar_parent = GameObject.Find("HpBar");

        hpBar = Instantiate(hpBarpref, hpBar_parent.transform);
        hpBar_script = hpBar.GetComponentInChildren<HpBar>();
        SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform_Player.position, transform.position) < 15f)
        {
            animator.SetBool("isOnFight", true);
        }
        else if (Vector3.Distance(transform_Player.position, transform.position) > 25f)
        {
            animator.SetBool("isOnFight", false);
        }
        if (hpBar.activeSelf)
        {
            hpBar_script.SendMessage("GetTransform", hpbar_position.transform);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (curHealth <= 0) return;
        if(other.tag == "Sword" && curHealth>0 && !immune)
        {
            int randint = Random.Range(1, 4);
            if (isCover)
            {
                curHealth -= player.damage / 2;
                StartCoroutine(BlockParticle());
            }
            else
            {
                curHealth -= player.damage;
                if (stiff)
                {
                    animator.SetInteger("isHit", randint);
                    StartCoroutine(StiffTimer());
                }
            }
            StartCoroutine(OnDamage());
            StopCoroutine("ShowHp");
            StartCoroutine("ShowHp");
            SetHpBar();
        }
        if (curHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }

    }
    void SetHpBar()
    {
        hpBar.GetComponent<HpBar>().HealthEffect(((float)curHealth / (float)maxHealth));
    }
    IEnumerator StiffTimer()
    {
        stiff = false;
        yield return new WaitForSeconds(15f);
        stiff = true;

    }    
    IEnumerator ShowHp()
    {
        hpBar.SetActive(true);
        Debug.Log("고블린 체력바 켜켜짐");
        yield return new WaitForSeconds(5f);
        Debug.Log("고블린 체력바 꺼짐");
        hpBar.SetActive(false);
    }
    IEnumerator BlockParticle()
    {
        blockParticle.Play();
        yield return new WaitForSeconds(0.5f);
        blockParticle.Stop();
    }
    IEnumerator OnDamage()
    {
        immune = true;
        Color curColor = mat.color;
        mat.color = Color.red;
        Time.timeScale = 0.4f;
        hit.Play();
        yield return new WaitForSeconds(0.1f);
        hit.Stop();
        Time.timeScale = 1.2f;
        mat.color = curColor;
        immune = false;
    }
    IEnumerator Dospell1()
    {
        yield return new WaitForSeconds(2f);
        GameObject intantSpell1 = Instantiate(spell1, spell1_Start.position, transform.rotation);
    }
}
