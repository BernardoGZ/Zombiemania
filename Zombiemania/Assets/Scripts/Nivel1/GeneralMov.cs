using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bernardo Garcia Zermeño
//A00570682
//Tarea Movimiento 3D 

public class GeneralMov : MonoBehaviour
{
    //Vector2 position;
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    // float firstpos;

    public Animator animator;

    public GameObject caminar;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Vector3 position = rb.position;
        // firstpos = position.x;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {            
            position.x = position.x + horizontal * Time.fixedDeltaTime * speed;               
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            position.y = position.y + vertical * Time.fixedDeltaTime * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Saltar
        {
            position.y = position.y + 5 * Time.fixedDeltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            //  GameObject clone = Instantiate(caminar) as GameObject;
            Instantiate(caminar);
            
        }
        if (Input.GetKeyUp(KeyCode.D)){
                var GO = GameObject.Find("caminar(Clone)");
                Destroy(GO);
        }
        
               
        rb.MovePosition(position);
    }

//     public void TiempoVida(GameObject g){
//         this.Destroy(caminar);
//     }
}
