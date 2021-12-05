using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : MonoBehaviour
{
    public int heal_Amount;
    float timer;
    Player player;
    float rotate_speed;

    // Start is called before the first frame update
    void Start()
    {
        heal_Amount = 30;
        timer = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        rotate_speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,rotate_speed * Time.deltaTime,0));
        timer += Time.deltaTime;
        if (timer > 50f) Destroy(gameObject, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject, 0);
        }
    }
}
