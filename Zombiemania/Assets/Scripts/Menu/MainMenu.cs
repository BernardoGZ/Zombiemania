using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject instructions;
//    public GameObject general;
//    NextLevel nextLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaJuego(){
        PlayerStats.Bullets = 16;
        SceneManager.LoadScene("Nivel1");
    }
    public void Salir(){
        Application.Quit();
    }
    public void InstrIn(){
        instructions.SetActive(true);
    }

    public void InstrOut(){
        instructions.SetActive(false);
    }
}
