using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float propulsion;
    void Update()
    {
        transform.Rotate(540,0,0); 

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.right*propulsion);   
    }
}
