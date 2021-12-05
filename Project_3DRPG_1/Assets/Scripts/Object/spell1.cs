using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell1 : MonoBehaviour
{
    public int damage;
    float timer;
    Player player;
    Vector3 movevec;
    Vector3 rotatevec;

    // Start is called before the first frame update
    void Start()
    {
        rotatevec = new Vector3(0, 0, 0);
        timer = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        movevec = (player.transform.position - transform.position).normalized;
        rotate();
        transform.LookAt(transform.position + rotatevec);
        transform.position += rotatevec * 5f * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 2.5f);
        timer += Time.deltaTime;
        if (timer > 15f) Destroy(gameObject, 0);        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!player.rollImmuneDamage)
                Destroy(gameObject, 0);
        }
    }
    public void rotate()
    {
        if (rotatevec.x < movevec.x)
        {
            rotatevec.x += 0.001f;
        }
        if (rotatevec.x > movevec.x)
        {
            rotatevec.x -= 0.001f;
        }
        if (rotatevec.z < movevec.z)
        {
            rotatevec.z += 0.001f;
        }
        if (rotatevec.z > movevec.z)
        {
            rotatevec.z -= 0.001f;
        }
    }
}
