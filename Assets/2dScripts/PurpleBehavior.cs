using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBehavior : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    private Vector2 initialPos;

    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        initialPos = gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.position = initialPos;
    }
}
