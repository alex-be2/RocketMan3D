using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*    [SerializeField] public float cMovementSpeed;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private Transform Player;*/
    private Vector3 offset = new Vector3 (0, 4, -15);
    private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetPos = target.position+offset;

        targetPos.y = 2f;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
        /*Debug.Log(targetPos);
        targetPos = transform.position-Player.position;
        Debug.Log(targetPos);
        //transform.position = transform.right;
        transform.position = Vector3.Lerp(transform.right, targetPos, cMovementSpeed*Time.deltaTime);*/
    }
}
