using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieMov : MonoBehaviour
{
    Rigidbody2D rb;
    float lastStep = 0f;
    float speed;
    GameObject general;
    NextLevel nextLevel;
    GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = -0.1f;
        general = GameObject.Find("General_0");
        mainCamera = GameObject.Find("MainCamera");
        nextLevel = general.GetComponent<NextLevel>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextLevel.nextLevel){
            speed = 0;
            Destroy(gameObject, 0.5f);
        }
    }

    private void FixedUpdate() {
        if (Time.time - lastStep > 0.05f) {
                lastStep = Time.time;
                GetComponent<Rigidbody2D> ().transform.Translate (speed, 0, 0);
        
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, LayerMask.GetMask("Player"));
        if(hit.collider != null){
            speed = -0.2f;
            // Debug.Log("Z collide G");
        }
        else{
            // Debug.Log("Z NOT collide G");
        }

        if(rb.position.x <= mainCamera.GetComponent<Transform>().position.x - 10){
            Destroy(gameObject);
        }
    }
    //No funciona debido a que los dos no tienen Trigger In
    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "MainCamera"){
            Destroy(gameObject);
        }
    }
}
