using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScenePlay : MonoBehaviour
{
    public GameObject player;
    public GameObject boss1;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            StartCoroutine("BossCutScenePlay");
        }
    }
    IEnumerator BossCutScenePlay()
    {
        SceneManager.LoadScene("bossCut", LoadSceneMode.Additive);
        player.SetActive(false);
        boss1.SetActive(false);
        canvas.SetActive(false);
        GameObject.Find("Music").transform.Find("Player_Walk").gameObject.SetActive(false);
        yield return new WaitForSeconds(29.5f);
        SceneManager.UnloadSceneAsync("bossCut");
        player.SetActive(true);
        boss1.SetActive(true);
        canvas.SetActive(true);
        player.transform.position = new Vector3(0, 0.5f, -4.5f);
        Destroy(gameObject, 0);
    }
}
