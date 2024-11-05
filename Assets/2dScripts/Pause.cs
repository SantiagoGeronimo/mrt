using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject hud;
    [SerializeField] PlayerMovement playerMovement;
    private bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            StartPause();
        }
    }

    private void StartPause()
    {
        pause.SetActive (true);
        hud.SetActive (false);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    private void StopPause ()
    {
        pause.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Resume()
    {
        StopPause();
    }

    public void Quit()
    {
        Application.Quit ();
    }

}
