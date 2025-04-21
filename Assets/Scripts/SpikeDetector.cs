using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        Debug.Log("hitSpike");

        if (other == playerCollider)
        {
            Player playerScript = player.GetComponent<Player>();

            playerScript.playerHealth -= 10f;
            Debug.Log("ouch");

        }

    }
}
