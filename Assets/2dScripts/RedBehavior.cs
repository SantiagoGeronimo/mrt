using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBehavior : MonoBehaviour
{
    private SpriteRenderer rendererComponent;

    private void Awake()
    {
        if (GetComponent<Renderer>() != null)
        {
            rendererComponent = GetComponent<SpriteRenderer>();
        }
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (rendererComponent.color == Color.red && collision.gameObject.tag == ("Player"))
        {
            var go = collision.gameObject.GetComponent<PlayerMovement>();
            if (go != null)
            {
                go.PlayerDeath();
            }

        }
    }
}
