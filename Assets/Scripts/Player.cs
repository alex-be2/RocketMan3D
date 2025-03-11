using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    [SerializeField] private Material playerMat;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMat.color = Color.blue;
    }

    void Update()
    {
        Movement();
    }

    Vector3 lastPosition = new Vector3();
    void Movement()
    {
        
        float speed = Vector3.Distance(lastPosition, transform.position) * 100f;

        lastPosition = transform.position;

        Debug.Log(speed);

        Transform floorScale = Floor.GetComponent<Transform>();

        float floorDist = (floorScale.localScale.y)/2; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.position.y - (floor.transform.position.y + floorDist));
            //Debug.Log(floorDist);



            if (transform.position.y - (floor.transform.position.y + floorDist) < 0.5)
            {
                rb.velocity += transform.up *Time.deltaTime * jumpPower;
            }
        }
        
        if (speed < 2.5 || transform.position.y - (floor.transform.position.y + floorDist) > 0.5)
        {
            if(speed < 10)
            {
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
    }
}
