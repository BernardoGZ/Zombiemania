using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCounts : MonoBehaviour
{
    // Start is called before the first frame update
    // static int zombieStatic;
    public int zombieCount;
    GameObject zombieText;
    public int bulletCount;
    GameObject bulletText;
    GameObject general;
    GameOver gameOver;

    private void Awake() {
        
    }
    
    void Start()
    {
        zombieCount = PlayerStats.Kills;
        bulletCount = PlayerStats.Bullets;
        zombieText = GameObject.Find("ScoreC");
        bulletText = GameObject.Find("AmmoC");
        general = GameObject.Find("General_0");
        gameOver = GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount = PlayerStats.Bullets;
        zombieText.GetComponent<Text>().text = zombieCount.ToString();                
        bulletText.GetComponent<Text>().text = bulletCount.ToString();        
                
        if(bulletCount == 0){
            PlayerStats.Died = "Muy pocas balas? Inténtalo otra vez :)" ;
            PlayerStats.Kills = zombieCount;
            gameOver.gameOver = true;
            
        }
    }
}
