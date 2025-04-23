using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            Player playerScript = player.GetComponent<Player>();
            playerScript.playerHealth -= 500f;
        }

    }
}
