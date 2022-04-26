using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    int isFightCount;
    // Start is called before the first frame update
    void Start()
    {
        isFightCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeIsFightCount(bool isFight)
    {

        if (isFight) isFightCount++;
        else isFightCount--;

        if (isFightCount > 0)
        {
            GameObject.Find("Music").transform.Find("BattleMusic").gameObject.SetActive(true);
        }
        else GameObject.Find("Music").transform.Find("BattleMusic").gameObject.SetActive(false);
    }
}
