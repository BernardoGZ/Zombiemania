using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieMov : MonoBehaviour
{
    Rigidbody2D rb;
    float lastStep = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (Time.time - lastStep > 0.05f) {
                lastStep = Time.time;
                GetComponent<Rigidbody2D> ().transform.Translate (-0.1f, 0, 0);
        
        }
    }
}
