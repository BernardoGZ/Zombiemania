using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneralMov : MonoBehaviour
{
    //Vector2 position;
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    public bool hasGun = false;
    public Animator animator;
    public GameObject caminar;
    public GameObject gun;
    public GameObject bullet;
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // gun = GameObject.Find("Weapon_0");
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
           
            Instantiate (bullet, new Vector3 (position.x + 2.0f, position.y + 1.0f, 0), Quaternion.identity);
            // bulletGo(GameObject.Find("Bullet(Clone)"));
            // if (Time.time - lastSpawned > 0.5f) {
            //     audio.Play (0);
                // lastSpawned = Time.time;
                // Instantiate (bullet, new Vector3 (transform.position.x + 1.5f, transform.position.y + 0.1f, 0), Quaternion.identity);
            // }
        }

         rb.MovePosition(position);

        //if (Input.GetKeyDown(KeyCode.Space)) //Saltar
        // {
        //     position.y = position.y + 5 * Time.fixedDeltaTime * speed;
        // }
        
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
         }
         if (other.tag == "Ammo") {
            Destroy(other.gameObject);       
         }

     }

    //  void bulletGo(GameObject bullet){
    //     // Vector3 pos = gun.GetComponent<Rigidbody2D>().position;
    //     Vector3 pos = rb.position;
    //     pos.x = pos.x + 1.5f* Time.fixedDeltaTime * speed;
    // }
}

   
