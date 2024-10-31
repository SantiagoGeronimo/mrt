using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color1;  
    [SerializeField] private Color color2; 
    [SerializeField] private float changeInterval = 5f;  
    private float timeElapsed = 0f;    
    private bool isColor1 = true;      


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = color1;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= changeInterval)
        { 
            spriteRenderer.color = isColor1 ? color2 : color1;

            isColor1 = !isColor1;

            timeElapsed = 0f;
        }
    }
}
