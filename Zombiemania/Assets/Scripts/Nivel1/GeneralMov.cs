using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralMov : MonoBehaviour
{
    //Vector2 position;
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    private float lastBullet = 0f;
    private float lastStep = 0f;
    public bool hasGun = false;
    public Animator animator;
    public GameObject caminar;
    public GameObject gun;
    public GameObject bullet;
    public GameObject mainCamera;
    public GameObject objZombie;
    GameObject general;
    private float speed = 5.0f;
    GameCounts gameCount;
    GameOver gameOver;
    BackgroundLoop backLoop;
    NextLevel nextLevel;
    bool gameObool;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameCount = GetComponent<GameCounts>();
        gameOver = GetComponent<GameOver>();
        backLoop = mainCamera.GetComponent<BackgroundLoop>();
        nextLevel = GetComponent<NextLevel>();
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
     if (!nextLevel.nextLevel)
     {
         Controller();
     } 
    }

    void Controller() {
        Vector3 position = rb.position;
        
        // Primary Movement
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {            
            if (nextLevel.nextLevel == false)
            {
                position.x = position.x + horizontal * Time.fixedDeltaTime * speed;  
            }
             
            
            //Audio Instantiate at walking
            if (Time.time - lastStep > 0.2f) {
                lastStep = Time.time;
                var GO = GameObject.Find("caminar(Clone)");
                Destroy(GO);
                Instantiate (caminar);                
             }            
        }
        if (((Input.GetKey(KeyCode.W) && position.y < 2.2) || (Input.GetKey(KeyCode.S) && position.y > -4)))
        {
            if(nextLevel.nextLevel == false){
                position.y = position.y + vertical * Time.fixedDeltaTime * speed;
            }
            

            //Audio Instantiate at walking
            if (Time.time - lastStep > 0.2f) {
                lastStep = Time.time;
                var GO = GameObject.Find("caminar(Clone)");
                Destroy(GO);
                Instantiate (caminar);                
             } 
        }
        
        if (Input.GetKey(KeyCode.Space)  && nextLevel.nextLevel == false) {
           
             if(hasGun){
                if (Time.time - lastBullet > 0.2f) {
                    lastBullet = Time.time;
                    Instantiate (bullet, new Vector3 (position.x + 1.2f, position.y + 0.8f, 0), Quaternion.identity);
                    gameCount.bulletCount -= 1;
                    
                }
             }
        }
         rb.MovePosition(position);
        
    }

     //Collide with gun gets the gun next to him at all time
     //Collide with Ammo boxes gives 200 extra bullets

     void OnTriggerEnter2D (Collider2D other) {
         if (other.tag == "Weapon") {
            hasGun = true;
            backLoop.scrollSpeed = 5;
            objZombie.GetComponent<ZombieAppear>().enabled = true;
            gun.GetComponent<FixedJoint2D>().enabled = true;
            gun.GetComponent<BoxCollider2D>().isTrigger = true;
         }
         if (other.tag == "Ammo") {
            Destroy(other.gameObject);
            gameCount.bulletCount += 50;       
         }
        if (other.tag == "MainCamera"){
            if(nextLevel.nextLevel){
                 SceneManager.LoadScene("Nivel2");
            }
            else{
                gameOver.gameOver = true;
            }

        }
        if (other.tag == "Zombie" && nextLevel.nextLevel == false){
            gameOver.gameOver = true;
        }
     }
}

   
