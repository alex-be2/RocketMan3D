using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlightScript : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 currentPos = transform.position;
        if (player.transform.position.x - currentPos.x > 50)
        {
            Destroy(gameObject);
        }
        //Debug.Log($"PLAYER: {player.transform.position.x}");
        //Debug.Log($"SUM: {player.transform.position.x - currentPos.x}");
    }
}
