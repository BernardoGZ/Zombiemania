using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleted : MonoBehaviour
{
    // Start is called before the first frame update
    int zombieCount;
    GameObject zombieText;
    
    void Start()
    {
        // gameOver = GetComponent<GameOver>();
        zombieCount = PlayerStats.Kills;
        zombieText = GameObject.Find("ScoreC");
    }

    // Update is called once per frame
    void Update()
    {
        zombieText.GetComponent<Text>().text = zombieCount.ToString();
    }

    public void backtoMenu(){
        PlayerStats.Kills = 0;
        SceneManager.LoadScene("Menu");        
    }

    public void Salir(){
        PlayerStats.Kills = 0;
        Application.Quit();
    }
}
