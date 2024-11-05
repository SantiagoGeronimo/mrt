using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBehavior : MonoBehaviour
{
    private SpriteRenderer rendererComponent;
    [SerializeField] private GreenPlatformSO greenPlatformSO;
    private bool isBouncing = false;
    private void Awake()
    {
        if (GetComponent<Renderer>() != null)
        {
            rendererComponent = GetComponent<SpriteRenderer>();
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rendererComponent.color = Color.green;
        if (collision.gameObject.tag == ("Player") && Input.GetButton("Jump") && !isBouncing)
        {
            isBouncing = true;
            var playerRb = collision.GetComponent<Rigidbody2D>();
            var playerMv = collision.GetComponent<PlayerMovement>();
            playerRb.velocity = Vector2.zero;
            playerRb.velocity = new Vector2(playerRb.velocity.x, greenPlatformSO.bouncePower);
            playerMv.bouncing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            var playerMv = collision.GetComponent<PlayerMovement>();
            playerMv.bouncing = false;
            isBouncing = false;
        }
        
    }

}
