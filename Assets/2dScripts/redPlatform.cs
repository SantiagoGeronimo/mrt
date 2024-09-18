using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPlatform : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color color1 = Color.blue;  // First color
    public Color color2 = Color.red; // Second color
    public Color destroyColor = Color.red;
    public float changeInterval = 5f;  // Time in seconds between color changes
    private float timeElapsed = 0f;    // Time tracker
    private bool isColor1 = true;      // Tracks which color is currently active

    void Start()
    {
        // Get the SpriteRenderer component attached to the platform
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the platform to the initial color (blue)
        spriteRenderer.color = color1;
    }

    void Update()
    {
        // Increment the timeElapsed counter
        timeElapsed += Time.deltaTime;

        // Check if the timeElapsed exceeds the changeInterval
        if (timeElapsed >= changeInterval)
        {
            // Toggle the platform's color between color1 and color2
            spriteRenderer.color = isColor1 ? color2 : color1;

            // Flip the boolean to track the current color
            isColor1 = !isColor1;

            // Reset the timeElapsed for the next interval
            timeElapsed = 0f;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // If the platform is red and an object enters the trigger area, destroy the object
        if (spriteRenderer.color == destroyColor)
        {
            Destroy(collision.gameObject);
        }
    }
}
