using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_Player: MonoBehaviour
{
    public Player player;
    public TextMeshPro healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.text =  player.curhealth.ToString();
    }
}
