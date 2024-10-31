using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class MovingBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int startingPoint;
    [SerializeField] private float pauseDuration;
    [SerializeField] private Transform[] points;
    private int i;
    private bool isMoving = true;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, points[i].position) < 0.1f)
            {
                StartCoroutine(PauseBeforeMoving());
            }
        }
    }

    IEnumerator PauseBeforeMoving()
    {
        isMoving = false;
        
        yield return new WaitForSeconds(pauseDuration);

        i++;
        if (i == points.Length)
        {
            i = 0;
        }

        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
