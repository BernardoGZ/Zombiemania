using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public bool inPause;

    // Start is called before the first frame update
    void Start()
    {
        inPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseInOut(){
        if(inPause){
            pause.SetActive(false);
            inPause = false;
            Time.timeScale = 1;
            
        }
        else{
            pause.SetActive(true);
            inPause = true;
            Time.timeScale = 0;
        }
    }

    public void GoBacktoMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
