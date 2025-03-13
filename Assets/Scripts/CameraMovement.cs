using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*    [SerializeField] public float cMovementSpeed;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private Transform Player;*/
    private Vector3 offset = new Vector3(0, 4, -15);
    private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    float scrollValue;
    float zoomValue;

    Vector3 lastPosition = new Vector3();

    void Update()
    {
        Vector3 targetPos = target.position + offset;

        targetPos.y = 2f;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");


        float speed = Vector3.Distance(lastPosition, target.transform.position) * 100f;

        lastPosition = target.transform.position;

        //Debug.Log(speed);

        if (speed < 20)
        {
            zoomValue = 0;
        }
        if (speed >= 50 && speed < 100)
        {
            zoomValue = 2.5f;
        }
        if (speed >= 100 && speed < 150)
        {
            zoomValue = 5;
        }
        if (speed >= 150 && speed < 250)
        {
            zoomValue = 7.5f;
        }
        if (speed >= 250)
        {
            zoomValue = 10;
        }
    
        //Debug.Log(offset);
        offset = new Vector3(0, 4, -15 - zoomValue);

        // if (scrollWheel != 0)
        // {
        //     scrollValue = scrollWheel;
        // }
        /*Debug.Log(targetPos);
        targetPos = transform.position-Player.position;
        Debug.Log(targetPos);
        //transform.position = transform.right;
        transform.position = Vector3.Lerp(transform.right, targetPos, cMovementSpeed*Time.deltaTime);*/
    }
}
