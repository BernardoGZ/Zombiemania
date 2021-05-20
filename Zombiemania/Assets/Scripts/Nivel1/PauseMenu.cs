using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject mainCamera;
    public GameObject General;
    public GameObject objZombie;
    GameObject Zombieclone;


// BackgroundLoop backLoop;
//     GeneralMov generalMov;
//     BackgroundLoop backLoop;

    public bool inPause;

    // Start is called before the first frame update
    void Start()
    {
        inPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Funcionaria si se pudiera tomar un conjunto de GO con el mismo nombre. Pero no es así
        //Solucion: Variable en zombie Mov
        // if (objZombie.GetComponent<ZombieAppear>().enabled == true)
        // {
        //     Zombieclone = GameObject.Find("ZombieNorm(Clone)");
        // }
        
    }
    public void PauseInOut(){
        if(inPause){
            pause.SetActive(false);
            inPause = false;
            mainCamera.GetComponent<BackgroundLoop>().enabled = true;
            General.GetComponent<GeneralMov>().enabled = true;
            // Zombieclone.GetComponent<ZombieMov>().enabled = true;
        }
        else{
            pause.SetActive(true);
            inPause = true;
            mainCamera.GetComponent<BackgroundLoop>().enabled = false;
            General.GetComponent<GeneralMov>().enabled = false;
            // Zombieclone.GetComponent<ZombieMov>().enabled = false;

        }
       

    }
}
