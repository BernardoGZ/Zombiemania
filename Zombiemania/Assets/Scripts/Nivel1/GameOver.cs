using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject general;
    public bool gameOver;
    
    public static int score;
    //Score es statico para que se pueda compartir entre escenas
   
    
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
            score = general.GetComponent<GameCounts>().zombieCount;

            Destroy(general);
            
            SceneManager.LoadScene("GameOver");
            
            
        }
    }
}
