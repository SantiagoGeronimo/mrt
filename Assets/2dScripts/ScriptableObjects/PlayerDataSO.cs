using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "ScriptableObjects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    public float jumpingPower;
    public float wallSlidingSpeed;

    [Header("Dash")]
    public float dashingPower = 18f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
}
