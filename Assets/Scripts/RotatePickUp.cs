using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickUp : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 180f * Time.deltaTime,0);
    }
}
