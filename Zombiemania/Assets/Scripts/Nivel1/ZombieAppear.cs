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
    // private GeneralMov genScript;


    // Start is called before the first frame update
    void Start () {
        //  zombie1 = GameObject.Find("ZombieNorm");
         mainCam = GameObject.Find("MainCamera");
        // genScript = general.GetComponent<GunnerMovement> ();
        StartCoroutine (ZombieApp ());

    }

    IEnumerator ZombieApp () {

        // while (true && genScript.isAlive) {
        while (true) {
            // xPos = Random.Range (20, 24);
            xPos = mainCam.GetComponent<Transform>().position.x + 5;
            // yPos = Random.Range (-4f, 2.2f);
            yPos = 0;

            // z = Random.Range(0, 2);
            // ZAppear = z < 1 ? zombie1 : zombie2);
            Instantiate (zombie1, new Vector3 (xPos, yPos, 0), Quaternion.identity);

            yield return new WaitForSeconds (1);
        }

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
