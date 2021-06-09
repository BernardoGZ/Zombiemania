using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMov : MonoBehaviour
{

    Rigidbody2D rb;
    GameCounts gameCount;
    public ParticleSystem particleZ;
    GameObject general;
    public float speed = 2.0f;
    public GameObject actScene;
    SceneManag sceneManag;
    static int bossShots;
    public NextLevel nextLevel;
    
    // public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        general = GameObject.Find("General_0");
        gameCount = general.GetComponent<GameCounts> ();
        nextLevel = general.GetComponent<NextLevel>();
        sceneManag = actScene.GetComponent<SceneManag>();
        // bossShots = 0;
        
    }

    // Update is called once per frame
    void Update()
    {        
    
    }

    private void FixedUpdate() {
       //AddForce permits the bullet to change constantly
       rb.AddForce(transform.right * 20f);
    }

    void OnTriggerEnter2D (Collider2D other) {
         if (other.tag == "Zombie") {
             Instantiate(particleZ, other.transform.position, Quaternion.identity);
             Destroy(other.gameObject);
             if(gameCount != null){
                gameCount.zombieCount += 1;
             }
             else{
                 Debug.Log("ErrorZ");
             }            
         }
         if (other.tag == "ZombieBoss") {
             bossShots += 1;
             Destroy(gameObject);
             if(bossShots >= 20){
                Instantiate(particleZ, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                nextLevel.nextLevel = true;
             }
             
         }

         if (other.tag == "MainCamera") {
             Destroy(gameObject);
         }

     }
}