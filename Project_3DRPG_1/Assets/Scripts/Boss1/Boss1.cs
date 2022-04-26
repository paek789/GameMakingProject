using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    [SerializeField]
    GameObject meteor;

    public Transform player;
    public float speed;
    public int damage;
    public int maxHealth;
    public int curHealth;
    public int runAwayCooltime, SummonTotemCoolTime, GrabCoolTime = 0;
    public ParticleSystem hit;
    public Material mat;
    public Color curColor;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        mat = GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().material;
        curColor = mat.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <=0) animator.SetBool("isDead", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword" && curHealth >0)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            curHealth -= player.damage;

            StartCoroutine(OnDamage());

            Debug.Log("근접공격 적중. 보스 현재체력 : " + curHealth);

        }
    }
    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        hit.Play();
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1.2f;
        hit.Stop();
        mat.color = curColor;
    }

    
    public IEnumerator RunAwayCoolDown()
    {
        while (runAwayCooltime!= 0)
        {
            yield return new WaitForSeconds(1);
            runAwayCooltime--;
        }        
    }
    public IEnumerator SummonTotemCoolDown()
    {
        while (SummonTotemCoolTime != 0)
        {
            yield return new WaitForSeconds(1);
            SummonTotemCoolTime--;
        }
    }

    public IEnumerator GrabCoolDown()
    {
        while (GrabCoolTime != 0)
        {
            yield return new WaitForSeconds(1);
            GrabCoolTime--;
        }
    }
    public IEnumerator DropMeteor()
    {
        for(int i = 0; i<30; i++)
        {
            float randomX = Random.Range(-22f, 22f);
            float randomZ = Random.Range(-22f, 22f);
            Instantiate(meteor, new Vector3(randomX, 0.5f, randomZ), Quaternion.identity);
            Debug.Log("메테오떨구기");
            yield return new WaitForSeconds(0.2f);
        }

    }
}
