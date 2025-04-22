using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpikeScript : MonoBehaviour
{
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 currentPos = transform.position;
        if (player.transform.position.x - currentPos.x > 50)
        {
            Destroy(gameObject);
        }
    }
}
