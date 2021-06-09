using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
     
    // Start is called before the first frame update

    // public GameOver gameOver;
    int zombieCount;
    GameObject zombieText;
    GameObject reasonText;
    
    void Start()
    {
        // gameOver = GetComponent<GameOver>();
        zombieCount = PlayerStats.Kills;
        zombieText = GameObject.Find("ScoreC");
        reasonText = GameObject.Find("Reason");
    }

    // Update is called once per frame
    void Update()
    {
        zombieText.GetComponent<Text>().text = zombieCount.ToString();
        reasonText.GetComponent<Text>().text = PlayerStats.Died;
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
