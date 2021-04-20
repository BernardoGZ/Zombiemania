using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject general;
    public bool gameOver;

   
    
    // Start is called before the first frame update
    void Start()
    {
        general = GameObject.Find("General_0");
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Destroy(general);
            // float time = Time.time;            
            // if (Time.time - time > 0.2f)
            // {
                SceneManager.LoadScene("GameOver");
            // }
            
        }
    }
}
