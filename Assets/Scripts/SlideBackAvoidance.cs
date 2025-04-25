using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlideBackAvoidance : MonoBehaviour
{
    [SerializeField] private GameObject CollisionDetector;
    private void OnTriggerStay(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider && CollisionDetector.GetComponent<ObstacleDetector>().detectedPlayer == true)
        {
            BoxCollider boxColliderDetector = gameObject.GetComponent<BoxCollider>();

            boxColliderDetector.isTrigger = false;

        }

    }
}
