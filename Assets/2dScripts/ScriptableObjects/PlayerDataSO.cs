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
}
