using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    public GameObject mainCamera;
    public GameObject objZombie;
    public GameObject txtCompleted;
    BackgroundLoop backscript;
    GameCounts gameCount;
    public bool nextLevel;
    public GameObject actScene;
    SceneManag sceneManag;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameCount = GetComponent<GameCounts>();
        backscript = mainCamera.GetComponent<BackgroundLoop>();
        nextLevel = false;
        sceneManag = actScene.GetComponent<SceneManag>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCount.zombieCount >= (PlayerStats.Kills + 8) || nextLevel == true){
            nextLevel = true;
            PlayerStats.Kills = gameCount.zombieCount;
            backscript.scrollSpeed = 0;
            if(sceneManag.actSceneIndex == 3){
                objZombie.GetComponent<ZombieBossAppear>().enabled = false;
            }
            else{
                objZombie.GetComponent<ZombieAppear>().enabled = false;
            }
            txtCompleted.SetActive(true);
            StartCoroutine(Goodbye());  
        }
    }

    IEnumerator Goodbye(){
        yield return new WaitForSeconds (5);
        StartCoroutine(moving());
            
    }
    IEnumerator moving(){
        while(true){
            rb.transform.Translate (0.1f, 0, 0);
            
            yield return new WaitForSeconds (1f);
        }
    }
    private void FixedUpdate() {

    }

}
