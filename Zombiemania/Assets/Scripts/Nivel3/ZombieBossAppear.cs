using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBossAppear : MonoBehaviour
{
    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombieBoss;
    // private GameObject ZAppear;
    private int z, k;
    public float lastZombie = 0f;
    public float xPos, yPos;
    GameObject mainCam;
    GameObject general;    
    public GameObject pause;
    public GameObject actScene;
    SceneManag sceneManag;
    NextLevel nextLevel;
    PauseMenu pauseMenu;
    public bool flag;
    // private GeneralMov genScript;


    // Start is called before the first frame update
    void Start () {
         mainCam = GameObject.Find("MainCamera");
         general = GameObject.Find("General_0");
         nextLevel = general.GetComponent<NextLevel>();
         pauseMenu = pause.GetComponent<PauseMenu>();
        sceneManag = actScene.GetComponent<SceneManag>();
        flag = true;   
        StartCoroutine (ZombieApp ());     
        StartCoroutine(BossApp());
    }

    IEnumerator ZombieApp () {
       
        while (flag) {
            xPos = mainCam.GetComponent<Transform>().position.x + 5;
            yPos = Random.Range (-4f, 2.2f);
            z = Random.Range(0, 5);
            Debug.Log(z);
            
            if(z >= 4 && sceneManag.actSceneIndex == 3){
                Instantiate (zombie2, new Vector3 (xPos, yPos, 0), Quaternion.identity);
                Debug.Log("ATENCION ZOMBIE 2!!!!");
            } 
            else {
                Instantiate (zombie1, new Vector3 (xPos, yPos, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds (3);
            if (nextLevel.nextLevel == true || pauseMenu.inPause == true){
                flag = false;
                Debug.Log("Stopped");
            }
        }

    }
    
    IEnumerator BossApp(){
        yield return new WaitForSeconds (5);
        xPos = mainCam.GetComponent<Transform>().position.x + 5;
        Instantiate (zombieBoss, new Vector3 (xPos, 0, 0), Quaternion.identity);
        StopCoroutine(ZombieApp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}