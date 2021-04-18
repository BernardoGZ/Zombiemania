using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMov : MonoBehaviour
{

    Rigidbody2D rb;
    // Rigidbody2D gunrb;
    // public GameObject gun;

    public float speed = 2.0f;
    
    // public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (rb.position.x > 50.0f ){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
       //AddForce permits the bullet to change constantly
       rb.AddForce(transform.right * 20f);
    }
}