using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckAvoidanceBottom : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            Player playerScript = player.GetComponent<Player>();

            playerScript.transform.position += transform.up * Time.deltaTime * 300;

        }

    }
}
