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
        //Debug.Log(transform.localEulerAngles.z);
        //Debug.Log(transform.eulerAngles.z);
        // if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270)
        // {
        //     Debug.Log("rotateBack");
        //     if (transform.localEulerAngles.x != 180)
        //     {
        //         //transform.Rotate(100, 0, 0);
        //         transform.Rotate(Vector3.right * Time.deltaTime);
        //     }
        //     else
        //     {
        //         transform.Rotate(0, 0, 0);
        //     }
        // }
        // if (transform.localEulerAngles.z < 90 && transform.localEulerAngles.z > 270)
        // {
        //     Debug.Log("rotateForward");
        //     if (transform.localEulerAngles.x != 0)
        //     {
        //         transform.Rotate(100, 0, 0);
        //     }
        //     else
        //     {
        //         transform.Rotate(0, 0, 0);
        //     }
        // }

    

    
        float facingAngle = transform.eulerAngles.z;

        if (facingAngle >= 180)
        {
                transform.Rotate(Vector3.forward *1000* Time.deltaTime);
        }
        
        //Debug.Log("Facing Angle: " + facingAngle);

        // if(transform.eulerAngles.z < 300 && transform.eulerAngles.z > 180)
        // {
        //     if (transform.eulerAngles.x != 180)
        //     {
        //         transform.Rotate(0, 1, 0);
        //         //transform.Rotate(Vector3.right * Time.deltaTime);
        //     }
        //     else
        //     {
        //         transform.Rotate(0, 0, 0);
        //     }
        // }
    }
}
