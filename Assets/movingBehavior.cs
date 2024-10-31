using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 pointA;  
    [SerializeField] private Vector2 pointB;  
    [SerializeField] private float speed = 2f;  
    [SerializeField] private float pauseDuration; 

    private Vector2 targetPosition;
    private bool isMoving = true;

    void Start()
    {
        // Start by moving towards pointB
        targetPosition = pointB;
    }

    void Update()
    {
         if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Checks if the object has reached the target position
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Start the pause coroutine before switching direction
                StartCoroutine(PauseBeforeMoving());
            }
        }
    }

    IEnumerator PauseBeforeMoving()
    {
        // Stop movement
        isMoving = false;

        // Wait for the specified pause duration
        yield return new WaitForSeconds(pauseDuration);

        // Switch target position and resume movement
        targetPosition = targetPosition == pointA ? pointB : pointA;
        isMoving = true;
    }
}
