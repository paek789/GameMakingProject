using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int damage;
    public int maxHealth;
    public int curHealth;
    public Image hpBar;
    public ParticleSystem hit;
    Color curColor;


    Animator animator;
    Rigidbody rigid;
    CapsuleCollider capsuleColider;
    Material mat;
    Material curmat;

    public int a=0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        capsuleColider = GetComponent<CapsuleCollider>();
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        mat = GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().material;
        curmat = mat;
        curColor = mat.color;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(curHealth <=0) animator.SetBool("isDead", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword" && curHealth >0)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            curHealth -= player.damage;

            StartCoroutine(OnDamage());

            hpBar.rectTransform.localScale = new Vector3((float)curHealth / (float)maxHealth, 1f, 1f);
            Debug.Log("근접공격 적중. 보스 현재체력 : " + curHealth);

        }
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        hit.Play();
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1f;
        hit.Stop();
        mat.color = curColor;
    }

    public IEnumerator Del()
    {
        while (a!=0)
        {
            yield return new WaitForSeconds(1);
            a--;
        }        
    }
}
