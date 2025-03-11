using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //movement
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;

    //world
    [SerializeField] private Transform floor;
    [SerializeField] private GameObject Floor;
    private Rigidbody rb;

    [SerializeField] private Material playerMat;

    [SerializeField] private GameObject spotLightBG;

    //[SerializeField] private List<GameObject> listOfLights = new List<GameObject>();

    [SerializeField] private Transform spotLightParent;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMat.color = Color.blue;

        //Instantiate(spotLightBG, transform.position, Quaternion.identity);
    }

    void Update()
    {
        Movement();
        ObjectInstantiation();
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
            //Debug.Log(transform.position.y - (floor.transform.position.y + floorDist));
            //Debug.Log(floorDist);



            if (transform.position.y - (floor.transform.position.y + floorDist) < 0.5)
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
        // if (speed < 2.5 || transform.position.y - (floor.transform.position.y + floorDist) > 0.5)
        // {
        //     if(speed < 10)
        //     {
        //     }
        // }
    }

        float positionCount;
    void ObjectInstantiation()
    {
        Vector3 playerPos = transform.position;
        
        float playerPosCount;

        // Debug.Log($"PLAYER:{playerPos.x}");
        
        // Debug.Log($"LIGHT:{positionCount}");
        
        
        
        if (playerPos.x >= positionCount)
        {
            Vector3 spotlightPos = new Vector3(positionCount+50,8f,4.3f);

            positionCount += 50;

            Instantiate(spotLightBG,spotlightPos,Quaternion.Euler(57,0,0),spotLightParent);
        }

    
    }



}

    
