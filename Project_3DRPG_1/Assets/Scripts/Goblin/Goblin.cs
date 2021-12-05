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
    public int maxHealth;
    public int curHealth;
    public Image hpBar;

    bool immune;

    int randint;
    bool infect;

    public CapsuleCollider meleeAttack_Goblin;

    Animator animator;
    Material mat;
    Material curmat;
    Collider[] colls;
    // Start is called before the first frame update
    void Start()
    {
        randint = Random.Range(1, 3);
        goblin = GetComponent<Transform>();
        transform_Player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        mat = transform.Find("Goblin Hunter").GetComponent<SkinnedMeshRenderer>().material;
        curmat = mat;
        //hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        colls = Physics.OverlapSphere(transform.position, 10);
        hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        infect = false;
        immune = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0) animator.SetInteger("isDead_goblin", randint % 2 + 1);
        else
        {

            if (animator.GetBool("onFight_goblin") && infect)
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
                infect = true;
            }
            else if (Vector3.Distance(transform_Player.position, transform.position) > 20f)
            {
                animator.SetBool("onFight_goblin", false);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" && curHealth > 0 && !immune)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            
            curHealth -= player.damage;

            StartCoroutine(OnDamage());

            hpBar.rectTransform.localScale = new Vector3((float)curHealth / (float)maxHealth, 1f, 1f);


            Debug.Log("근접공격 적중. 고블린 현재체력 : " + curHealth);

        }
    }
    void onfight()
    {
        animator.SetBool("onFight_goblin", true);
        infect = false;
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


    public IEnumerator arrowShot()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject intantarrow = Instantiate(arrow, arrowstart.position, transform.rotation);
        Rigidbody arrowRigid = intantarrow.GetComponent<Rigidbody>();
        arrowRigid.velocity = transform.forward * 10;
    }

} 
