using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class RotateLauncher : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float facingAngle = transform.eulerAngles.z;

        if (facingAngle >= 180)
        {
                transform.Rotate(Vector3.forward *1000* Time.deltaTime);
        }
        
    }
}
