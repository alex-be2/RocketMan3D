using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            Debug.Log("spike hit");
            Player playerScript = player.GetComponent<Player>();
            playerScript.playerHealth -= 48f;
        }

    }
}
