using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpHeight;
    public Rigidbody2D Rb;
    public RayCastJump checkGround;

    //collider del buho
    BoxCollider2D OwlCollider;
    float owl_ScaleX, owl_ScaleY, owl_ScaleZ;


    //animaciones
    public Animator anim;


    void Start()
    {

        //animaciones
        anim = GetComponent<Animator>();

    }


    void Update()
        { //movimiento y salto
            if (Input.GetKey(KeyCode.D))
            {
                Rb.velocity = new Vector2(+speed, Rb.velocity.y);
                transform.localScale = new Vector3(1.5f, 1.5f, 1);

                anim.SetBool("IsRunning", true);
             
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("IsRunning", false);
         
            }

            if (Input.GetKey(KeyCode.A))
            {
                Rb.velocity = new Vector2(-speed, Rb.velocity.y);
                transform.localScale = new Vector3(-1.5f, 1.5f, 1);

                anim.SetBool("IsRunning", true);
              
        }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("IsRunning", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && checkGround.IsGrounded())
            {
                Rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

                anim.SetBool("InFloor", true);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                anim.SetBool("InFloor", false);
            }

            //convertirse en buho
            if (Input.GetKey(KeyCode.O))
            {
                anim.SetBool("PressO", true);

                OwlCollider = GetComponent<BoxCollider2D>();

                owl_ScaleX = 0.2f;
                owl_ScaleY = 0.2f;
                owl_ScaleZ = 0.2f;

              OwlCollider.size = new Vector3(owl_ScaleX, owl_ScaleY, owl_ScaleZ);
            }
         
    }

        //plataforma
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platform")
            {
                transform.parent = collision.transform;
            }
        }
       private void OnCollisionExit2D(Collision2D collision)
       {
 
        if (collision.gameObject.tag == "Platform")
           {
           

               transform.parent = null;
           }
       }


    //DeathZone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            SceneManager.LoadScene("juegoi");
        }
    }

    //sandia
    private void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

}





