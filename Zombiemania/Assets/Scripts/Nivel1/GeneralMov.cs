using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneralMov : MonoBehaviour
{
    //Vector2 position;
    Rigidbody2D rb;
    float horizontal;
    float vertical;

    private float lastBullet = 0f;
    public bool hasGun = false;
    public Animator animator;
    public GameObject caminar;
    public GameObject gun;
    public GameObject bullet;
    public GameObject mainCamera;
    GameObject general;
    private float speed = 10.0f;
    BackgroundLoop backscript;
    GameCounts gameCount;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameCount = GetComponent<GameCounts>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        animator.SetFloat("VSpeed",Mathf.Abs(vertical));

    }

    private void FixedUpdate() {
        Controller();
    }

    void Controller() {
        Vector3 position = rb.position;
        
        // Primary Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {            
            position.x = position.x + horizontal * Time.fixedDeltaTime * speed;               
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            position.y = position.y + vertical * Time.fixedDeltaTime * speed;
        }
        
        if (Input.GetKey(KeyCode.Space)) {
           
             if (Time.time - lastBullet > 0.02f) {
                lastBullet = Time.time;
                Instantiate (bullet, new Vector3 (position.x + 1.2f, position.y + 0.8f, 0), Quaternion.identity);
                gameCount.bulletCount -= 1;
                
             }
        }

         rb.MovePosition(position);

        
        //Audio Instantiate at walking
        if (Input.GetKeyDown(KeyCode.D)){
            Instantiate(caminar);            
        }
        if (Input.GetKeyUp(KeyCode.D)){
                var GO = GameObject.Find("caminar(Clone)");
                Destroy(GO);
        }
    }

     //Collide with gun gets the gun next to him at all time
     void OnTriggerEnter2D (Collider2D other) {
         if (other.tag == "Weapon") {
            hasGun = true;        
            gun.GetComponent<FixedJoint2D>().enabled = true;
            gun.GetComponent<BoxCollider2D>().isTrigger = true;
         }
         if (other.tag == "Ammo") {
            Destroy(other.gameObject);       
         }

     }
}

   
