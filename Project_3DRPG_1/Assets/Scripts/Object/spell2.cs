using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell2 : MonoBehaviour
{
    public int damage;
    public MeshRenderer mesh;
    public CapsuleCollider range;
    float timer;
    Player player;
    Vector3 movevec;
    

    void Start()
    {
        timer = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    void Update()
    {
        if (gameObject)
        {
            timer += Time.deltaTime;
            if (timer < 2.0f)
            {
                movevec = player.transform.position;
                movevec.y += 0.1f;
                transform.position = movevec;
            }
            else if (timer < 2.2f)
            {
                GameObject.Find("Music").transform.Find("Demon_Spell2").gameObject.SetActive(true);
                range.enabled = true;
            }
            else
            {
                mesh.enabled = false;
                range.enabled = false;
            }
            if (timer > 10f) Destroy(gameObject, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(transform.parent.gameObject, 2f);
    }
}
