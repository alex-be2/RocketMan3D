using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    public Boolean detectedPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            Player playerScript = player.GetComponent<Player>();

            playerScript.speedCap = 0f;
            detectedPlayer = true;

            if (playerScript.ammo == 0)
            {
                playerScript.ammo += 1;
            }

        }

    }
}
