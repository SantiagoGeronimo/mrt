using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRoomManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Rigidbody2D player;

    [Header("Rooms")]
    [SerializeField] private Transform room1;
    [SerializeField] private Transform room2;
    [SerializeField] private Transform room3;
    [SerializeField] private Transform room4;
    [SerializeField] private Transform room5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            player.position = room1.transform.position;
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            player.position = room2.transform.position;
        } 
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            player.position = room3.transform.position;
        } 
        else if (Input.GetKeyUp(KeyCode.F4))
        {
            player.position = room4.transform.position;
        } 
        else if (Input.GetKeyUp(KeyCode.F5))
        {
            player.position = room5.transform.position;
        }
    }
}
