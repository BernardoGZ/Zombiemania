using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Doesnt work yet

public class AmmoAppear : MonoBehaviour
{
    
    public GameObject box;
    
    GameObject maincam;
    Rigidbody2D rbCam;
    public float xPos, yPos;
    float posCam;
    


    // Start is called before the first frame update
    void Start () {
        maincam = GameObject.Find("MainCamera"); 
        rbCam = maincam.GetComponent<Rigidbody2D>();
    }

    // IEnumerator AmmoApp () {

    //     while (true) {
    //         xPos = mainCam.GetComponent<Transform>().position.x + 5;
    //         yPos = Random.Range (-3f, 2.5f);

    //         Instantiate (box, new Vector3 (xPos, yPos, 0), Quaternion.identity);

    //         yield return new WaitForSeconds (1);
    //     }

    // }

    public void AmmoApp () {
        
            xPos = maincam.GetComponent<Transform>().position.x + 5;
            yPos = Random.Range (-3f, 2.5f);

            Instantiate (box, new Vector3 (xPos, yPos, 0), Quaternion.identity);

    }


    // Update is called once per frame
    void Update()
    {
        posCam = rbCam.position.x;

        if(posCam%25 == 0)
        {
            AmmoApp();
            // StartCoroutine (AmmoApp ());
        }
        
    }
}
