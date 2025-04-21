using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBoostDetector : MonoBehaviour
{

    [SerializeField] private GameObject CollionDetector;
    private void OnTriggerStay(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider && CollionDetector.GetComponent<ObstacleDetector>().detectedPlayer == true)
        {
            Player playerScript = player.GetComponent<Player>();

            playerScript.speedCap = 40f;

        }

    }
}
