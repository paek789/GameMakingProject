using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    public int curhealth;
    public int damage;
    public bool isb;
    public bool isd;
    public bool invincibility;


    public float hAxis;
    public float vAxis;
    public bool vDown;
    public bool hDown;
    public bool sDown;
    public bool mlDown;
    public bool mrDown;
    public bool mrUp;
    public bool spaceDown;
    float timer;
    float dash_timer;

    public Image hpBar;

    public bool rollImmuneDamage; 

    public Vector3 moveVec;
    public Vector3 rotateVec;
    Vector3 damagevec;

    Material mat;
    Animator animator;
    ParticleSystem blockParticle;
    public ParticleSystem fireParticle1, fireParticle2, sparkParticle1, sparkParticle2, potionParticle;
    public TutorialManager tutorialManager;
    public GameObject hitScreen;
    Color curColor;

    public Transform player;
    int getdamage;

    void Start()
    {
        animator = GetComponent<Animator>();
        mat = GameObject.Find("skeleton_mesh").GetComponent<SkinnedMeshRenderer>().material;
        blockParticle = GameObject.Find("Shockwave").GetComponent<ParticleSystem>();
        tutorialManager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
        isb = false;
        isd = false;
        rollImmuneDamage = false;
        rotateVec = new Vector3(0, 0, 0).normalized;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        timer = 1f;
        dash_timer = 0f;
        invincibility = false;
        curColor = mat.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (curhealth <= 0) animator.SetBool("isDead", true);
        if (timer < 0.3f)
        {
            transform.position += -transform.forward * 3 * Time.deltaTime;
            timer += 0.005f;
        }
        getInput();
    }
    void getInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        vDown = Input.GetButton("Vertical");
        hDown = Input.GetButton("Horizontal");
        sDown = Input.GetKeyDown(KeyCode.LeftShift);
        mlDown = Input.GetMouseButtonDown(0);
        mrDown = Input.GetMouseButton(1);
        mrUp = Input.GetMouseButtonUp(1);
        spaceDown = Input.GetButtonDown("Roll");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!invincibility && curhealth > 0)
        {
            if (!rollImmuneDamage)
            {
                if (other.tag == "MeleeAttackRange" || other.tag == "MeleeAttackRange2" || other.tag == "hand.R" || other.tag == "arrow" || other.tag == "DemonMeleeAttack")
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
                    {
                        StartCoroutine(BlockParticle());
                        damageRoutine(0.4f, true, other);
                    }
                    else damageRoutine(1, false, other);
                }
                else if (other.tag == "JumpAttackRange" || other.tag == "spell1" || other.tag == "spell2" || other.tag == "trap" || other.tag == "trap1" || other.tag == "trap2")
                {
                    damageRoutine(1, false, other);
                }
            }
            else if (other.tag == "JumpAttackRange")
            {
                damageRoutine(1, false, other);
            }
            else if (rollImmuneDamage) Debug.Log("구르기 무적으로 회피.");

            if(other.tag == "Item_Health")
            {
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                gameManager.remainPotion++;
                gameManager.player_remainPotion.text = "" + gameManager.remainPotion;
                Debug.Log(other.tag);}

        }
    }
    private void damageRoutine(float rate, bool isblock, Collider other)
    {
        if (other.tag == "MeleeAttackRange" || other.tag == "MeleeAttackRange2" || other.tag == "JumpAttackRange" || other.tag == "JumpAttackRange")
        {
            Boss1 boss1 = GameObject.Find("Boss1").GetComponent<Boss1>();
            damagevec = new Vector3(boss1.transform.position.x, transform.position.y, boss1.transform.position.z);
            getdamage = boss1.damage;
        }
        else if (other.tag == "hand.R")
        {
            //Goblin goblin = GameObject.Find("Goblin1").GetComponent<Goblin>();
            Goblin goblin = other.GetComponentInParent<Goblin>();
            damagevec = new Vector3(goblin.transform.position.x, transform.position.y, goblin.transform.position.z);
            getdamage = goblin.damage;
        }
        else if (other.tag == "arrow")
        {
            arrow arrow = other.GetComponentInParent<arrow>();
            damagevec = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            getdamage = arrow.damage;
        }
        else if(other.tag == "DemonMeleeAttack")
        {

            Demon demon = other.GetComponentInParent<Demon>();
            damagevec = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            getdamage = demon.damage;
        }
        else if(other.tag == "spell1")
        {
            spell1 spell1 = other.GetComponent<spell1>();
            StartCoroutine(SparkParticle());
            damagevec = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            getdamage = spell1.damage;
        }
        else if (other.tag == "spell2")
        {
            spell2 spell2 = other.GetComponentInParent<spell2>();
            StartCoroutine(FireParticle());
            damagevec = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            getdamage = spell2.damage;
        }
        else if (other.tag == "trap" || other.tag == "trap1" || other.tag == "trap2")
        {
            if(other.tag == "trap")
            {
                trap trap = other.GetComponent<trap>();
                StartCoroutine(FireParticle());
                getdamage = trap.damage;
            }
            else if (other.tag == "trap1")
            {
                trap1 trap1 = other.GetComponent<trap1>();
                StartCoroutine(FireParticle());
                getdamage = trap1.damage;

            }
            else if (other.tag == "trap2")
            {
                trap2 trap2 = other.GetComponent<trap2>();
                StartCoroutine(FireParticle());
                getdamage = trap2.damage;
            }

            damagevec = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        }


        curhealth -= (int)(getdamage*rate);
        transform.LookAt(damagevec);

        if (other.tag == "JumpAttackRange")
        {
            animator.SetTrigger("getHit2");
        }

        else if (!isblock)
        { 
            animator.SetTrigger("getHit");
            timer = 0;
        }
        

        StartCoroutine(OnDamage());

        hpBar.rectTransform.localScale = new Vector3((float)curhealth / (float)health, 1f, 1f);

        
    }
    public void Potionparticle()
    {
        StartCoroutine(PotionParticle());
    }
    public IEnumerator onimmuneDamage()
    {
        rollImmuneDamage = true;
        yield return new WaitForSeconds(0.3f);
        rollImmuneDamage = false;
    }
    
    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        hitScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitScreen.SetActive(false);
        mat.color = curColor;
    }
    IEnumerator BlockParticle()
    {
        blockParticle.Play();
        yield return new WaitForSeconds(0.5f);
        blockParticle.Stop();
    }
    IEnumerator SparkParticle()
    {
        sparkParticle1.Play();
        sparkParticle2.Play();
        yield return new WaitForSeconds(1.5f);        
        sparkParticle1.Stop();
        sparkParticle2.Stop();
    }
    IEnumerator FireParticle()
    {
        fireParticle1.Play();
        fireParticle2.Play();
        yield return new WaitForSeconds(3f);
        fireParticle1.Stop();
        fireParticle2.Stop();
    }
    IEnumerator PotionParticle()
    {
        potionParticle.Play();
        yield return new WaitForSeconds(1f);
        potionParticle.Stop();
    }

    IEnumerator Dash()
    {
        speed *= 3;
        yield return new WaitForSeconds(0.3f);
        speed /= 3;
    }
}