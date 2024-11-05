using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDashCdHud : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        if (player.canDash)
        {
            text.text = "Dash: available";
        }
        else
        {
            text.text = "Dash: cooldown";
        }
    }
}
