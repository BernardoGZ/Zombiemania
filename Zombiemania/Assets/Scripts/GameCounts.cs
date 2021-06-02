using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCounts : MonoBehaviour
{
    // Start is called before the first frame update
    public int zombieCount;
    GameObject zombieText;
    public int bulletCount;
    GameObject bulletText;
    GameObject general;
    GameOver gameOver;



    void Start()
    {
        zombieCount = zombieCount;
        bulletCount = 50;
        zombieText = GameObject.Find("ScoreC");
        bulletText = GameObject.Find("AmmoC");
        general = GameObject.Find("General_0");
        gameOver = GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        zombieText.GetComponent<Text>().text = zombieCount.ToString();
                
        bulletText.GetComponent<Text>().text = bulletCount.ToString();
                
        if(bulletCount == 0){
            gameOver.gameOver = true;
        }
    }
}
