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
    // public int level;
    // bool bye;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameCount = GetComponent<GameCounts>();
        backscript = mainCamera.GetComponent<BackgroundLoop>();
        nextLevel = false;
        // level = level + 1;
        // Debug.Log(">>>>>>>> NIVEL :     " + level);
        // bye = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCount.zombieCount >= 10){
            nextLevel = true;
            backscript.scrollSpeed = 0;
            objZombie.GetComponent<ZombieAppear>().enabled = false;
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
        // if (bye){
        //     if (Time.time - lastStep > 0.05f) {
        //         lastStep = Time.time;
        //         GetComponent<Rigidbody2D> ().transform.Translate (-0.1f, 0, 0);
        
        //     }
        // }
    }

}
