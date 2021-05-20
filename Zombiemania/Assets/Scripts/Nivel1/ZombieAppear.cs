using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAppear : MonoBehaviour
{
    public GameObject zombie1;
    // public GameObject zombie2;
    // private GameObject ZAppear;
    // private int z;
    public float lastZombie = 0f;
    public float xPos, yPos;
    GameObject mainCam;
    GameObject general;    
    public GameObject pause;
    NextLevel nextLevel;
    PauseMenu pauseMenu;
    public bool flag;
    // private GeneralMov genScript;


    // Start is called before the first frame update
    void Start () {
        //  zombie1 = GameObject.Find("ZombieNorm");
         mainCam = GameObject.Find("MainCamera");
         general = GameObject.Find("General_0");
         nextLevel = general.GetComponent<NextLevel>();
         pauseMenu = pause.GetComponent<PauseMenu>();
        // genScript = general.GetComponent<GunnerMovement> ();
        flag = true;   
        StartCoroutine (ZombieApp ());     
    }

    IEnumerator ZombieApp () {

       
        while (flag) {
            xPos = mainCam.GetComponent<Transform>().position.x + 5;
            // xPos = Random.Range (20, 24);
            yPos = Random.Range (-4f, 2.2f);
            // yPos = 0;

            // z = Random.Range(0, 2);
            // ZAppear = z < 1 ? zombie1 : zombie2);
            Instantiate (zombie1, new Vector3 (xPos, yPos, 0), Quaternion.identity);

            yield return new WaitForSeconds (1);
            if (nextLevel.nextLevel == true || pauseMenu.inPause == true){
                flag = false;
                Debug.Log("Stopped");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
