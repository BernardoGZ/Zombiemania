using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject general;
    bool gameover = false;
    
    // Start is called before the first frame update
    void Start()
    {
        general = GameObject.Find("General_0");
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameOver)
        // {
        //     Destroy(general);
        //     float time = time.time;
        //     if (Time.time - time < 0.5f)
        //     {
        //         SceneManager.LoadScene(scene);    
        //     }
            
        // }
    }
}
