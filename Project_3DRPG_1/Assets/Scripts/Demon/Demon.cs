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
    public Image hpBar;
    bool stiff;
    bool immune;
    public bool isCover;
    public BoxCollider meleeAttack_range;
    
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
        hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        immune = false;
        stiff = true;
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
            hpBar.rectTransform.localScale = new Vector3((float)curHealth / (float)maxHealth, 1f, 1f);
        }
        if (curHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }
    IEnumerator StiffTimer()
    {
        stiff = false;
        yield return new WaitForSeconds(15f);
        stiff = true;

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
        yield return new WaitForSeconds(0.1f);
        mat.color = curColor;
        immune = false;
    }
    IEnumerator Dospell1()
    {
        yield return new WaitForSeconds(2f);
        GameObject intantSpell1 = Instantiate(spell1, spell1_Start.position, transform.rotation);
    }
}
