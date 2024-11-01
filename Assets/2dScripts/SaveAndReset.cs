using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndReset : MonoBehaviour
{
    public Vector2 ResetPosition { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetSavedPosition()
    {
        return ResetPosition;
    }
    public void SavePosition(Vector2 t)
    {
        ResetPosition = t;
    }
}
