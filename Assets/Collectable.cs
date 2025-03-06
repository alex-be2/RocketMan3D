using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(90f * Time.deltaTime, 180f * Time.deltaTime, 270f * Time.deltaTime);
    }
}