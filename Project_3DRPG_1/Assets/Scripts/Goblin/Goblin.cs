using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{

    public GameObject arrow;
    public Transform arrowstart;
    public Transform transform_Player;
    public Transform goblin;
    public float speed;
    public int damage;
    public float maxHealth;
    public int curHealth;
    public ParticleSystem hit;

    MusicController musicController;
    TutorialManager tutorialManager;
    bool immune;
    bool isdead;
    int randint;
    bool fightInfect;

    public GameObject hpBarpref;
    GameObject hpBar_parent;
    GameObject hpBar;
    HpBar hpBar_script;

    public CapsuleCollider meleeAttack_Goblin;

    Animator animator;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        randint = Random.Range(1, 3);
        goblin = GetComponent<Transform>();
        transform_Player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        mat = transform.Find("Goblin Hunter").GetComponent<SkinnedMeshRenderer>().material;
        fightInfect = false;
        immune = false;
        isdead = false;
        tutorialManager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
        musicController = GameObject.Find("Music").GetComponent<MusicController>();
        hpBar_parent = GameObject.Find("HpBar");

        hpBar = Instantiate(hpBarpref, hpBar_parent.transform);
        hpBar_script = hpBar.GetComponentInChildren<HpBar>();
        SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0 && isdead == false) 
        {
            animator.SetInteger("isDead_goblin", randint % 2 + 1);
            isdead = true;
            if (tutorialManager.goblin_die == 0)
            {                
                tutorialManager.goblin_die++;
                tutorialManager.TutorialUpdate();
            }
        }
        else
        {
            if (animator.GetBool("onFight_goblin") && fightInfect)
            {
                Collider[] colls = Physics.OverlapSphere(transform.position, 10);
                for (int i = 0; i < colls.Length; ++i)
                {
                    colls[i].SendMessage("onfight", SendMessageOptions.DontRequireReceiver);
                }
            }
            if (Vector3.Distance(transform_Player.position, transform.position) < 10f)
            {
                animator.SetBool("onFight_goblin", true);
                fightInfect = true;
            }
            else if (Vector3.Distance(transform_Player.position, transform.position) > 20f)
            {
                animator.SetBool("onFight_goblin", false);
            }
        }
        if(hpBar.activeSelf) hpBar_script.SendMessage("GetTransform", transform);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" && curHealth > 0 && !immune)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();                       
            curHealth -= player.damage;
            
            StartCoroutine(OnDamage());
            StopCoroutine("ShowHp");
            StartCoroutine("ShowHp");
            SetHpBar();
        }
    }
    void SetHpBar()
    {
        hpBar.GetComponent<HpBar>().HealthEffect(((float)curHealth/ (float)maxHealth));
    }
    void onfight()
    {
        animator.SetBool("onFight_goblin", true);
        fightInfect = false;
    }

    IEnumerator OnDamage()
    {
        immune = true;
        Color curColor = mat.color;
        hit.Play();
        mat.color = Color.red;
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1.2f;
        mat.color = curColor;
        hit.Stop();
        immune = false;
    }
    IEnumerator ShowHp()
    {
        hpBar.SetActive(true);        
        yield return new WaitForSeconds(2f);
        hpBar.SetActive(false);
    }

    public IEnumerator arrowShot()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject intantarrow = Instantiate(arrow, arrowstart.position, transform.rotation);
        Rigidbody arrowRigid = intantarrow.GetComponent<Rigidbody>();
        arrowRigid.velocity = (transform.forward + new Vector3(0,0.2f,0)) * 20;
        yield return new WaitForSeconds(0.3f);
    }

} 
