using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] private Transform floor;
    [SerializeField] private GameObject Floor;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform floorScale = Floor.GetComponent<Transform>();

            float floorDist = (floorScale.localScale.y)/2; 
            
            Debug.Log(transform.position.y - (floor.transform.position.y + floorDist));
            Debug.Log(floorDist);



            if (transform.position.y - (floor.transform.position.y + floorDist) < 1.0)
            {
                rb.velocity += transform.up *Time.deltaTime * jumpPower;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += transform.right * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity -= transform.right * Time.deltaTime * movementSpeed;
        }
    }
}
