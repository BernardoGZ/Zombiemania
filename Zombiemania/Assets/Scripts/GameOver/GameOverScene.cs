using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
     
    // Start is called before the first frame update

    GameOver score;
    int zombieCount;
    GameObject zombieText;
    
    void Start()
    {
        score = GetComponent<GameOver>();
        zombieCount = GameOver.score;
        zombieText = GameObject.Find("ScoreC");
    }

    // Update is called once per frame
    void Update()
    {
        zombieText.GetComponent<Text>().text = zombieCount.ToString();
    }

    public void backtoMenu(){
        SceneManager.LoadScene("Menu");          
    }

    public void Salir(){
        Application.Quit();
    }

    

}
