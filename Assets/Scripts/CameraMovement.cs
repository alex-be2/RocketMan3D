using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(10, 4, -15);
    private float smoothTime = 0.25f;
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetPos = target.position + offset;

        targetPos.y = 2f;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
    }
}
