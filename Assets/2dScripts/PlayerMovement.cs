using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxJumpTime;
    [SerializeField] private float extraJumpForce;
    private bool isJumping;
    private float jumpTimeCounter;
    private Rigidbody2D rb;
    private bool grounded;

    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moverse en eje X con Flechas
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        // Inicia el salto
        if (Input.GetKey(KeyCode.UpArrow) &&  rb.velocity.y > 0 && grounded)
        {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
        }

        // Si se mantiene la tecla presionada y aún no ha comenzado a caer
        if (Input.GetKey(KeyCode.UpArrow) && isJumping && rb.velocity.y > 0)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce + extraJumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // Si el jugador suelta la tecla o comienza a caer
        if (Input.GetKeyUp(KeyCode.UpArrow) || rb.velocity.y <= 0)
        {
            isJumping = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isJumping = false;
            grounded = true;
        }
    }
}
