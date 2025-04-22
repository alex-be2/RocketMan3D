using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        //Debug.Log("hitSpike");

        if (other == playerCollider)
        {
            Player playerScript = player.GetComponent<Player>();
            //playerScript.playerHealth = Mathf.Lerp(playerScript.playerHealth, playerScript.playerHealth-10, 0.1f);
            playerScript.playerHealth -= 500f;
            //Debug.Log("ouch");

        }

    }
}
