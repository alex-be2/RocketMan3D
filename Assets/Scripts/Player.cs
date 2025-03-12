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
    //player material
    [SerializeField] private Material playerMat;
    //spotlights
    [SerializeField] private GameObject spotLightBG;
    [SerializeField] private Transform spotLightParent;
    //RocketLauncher
    [SerializeField] private Transform rocketLauncher;
    [SerializeField] private float rocketLauncherRotationSpeed;
    [SerializeField] private GameObject RocketPrefab;
    private Quaternion rocketLauncherRotation;
    [SerializeField] private float initialRocketPropulsion;

    ///
    /// 
    ///
    private Rigidbody rb;
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
        RocketLauncher();
    }

    Vector3 lastPosition = new Vector3();
    void Movement()
    {

        float speed = Vector3.Distance(lastPosition, transform.position) * 100f;

        lastPosition = transform.position;

        //Debug.Log(speed);

        Transform floorScale = Floor.GetComponent<Transform>();

        float floorDist = (floorScale.localScale.y) / 2;

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     //Debug.Log(transform.position.y - (floor.transform.position.y + floorDist));
        //     //Debug.Log(floorDist);



        //     if (transform.position.y - (floor.transform.position.y + floorDist) < 0.5)
        //     {
        //         rb.velocity += transform.up *Time.deltaTime * jumpPower;
        //     }
        // }

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

        //float playerPosCount;

        // Debug.Log($"PLAYER:{playerPos.x}");

        // Debug.Log($"LIGHT:{positionCount}");



        if (playerPos.x >= positionCount)
        {
            Vector3 spotlightPos = new Vector3(positionCount + 50, 8f, 4.3f);

            positionCount += 50;

            GameObject spotLight = Instantiate(spotLightBG, spotlightPos, Quaternion.Euler(57, 0, 0), spotLightParent);
        }


    }
    void RocketLauncher()
    {
        //controlls
        if (Input.GetKey(KeyCode.Q))
        {
            rocketLauncher.transform.Rotate(0, 0, rocketLauncherRotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rocketLauncher.transform.Rotate(0, 0, -rocketLauncherRotationSpeed * Time.deltaTime, Space.Self);
        }

        //Firing the launcher


        // if(delayTime>2f)
        // {
        // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rocketLauncherRotation = rocketLauncher.rotation;
            GameObject rocket = Instantiate(RocketPrefab, rocketLauncher.position + rocketLauncher.right*1.4f, rocketLauncherRotation);

            Rigidbody rb = rocket.GetComponent<Rigidbody>();
            rb.AddForce(rocket.transform.right * initialRocketPropulsion);
        }


    }



}


