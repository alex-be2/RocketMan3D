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

    [SerializeField] private Transform rockets;

    [SerializeField] private Transform MapParent;
    [SerializeField] private GameObject BasicMap;
    [SerializeField] private GameObject BasicMapNotBaked;
    [SerializeField] private GameObject HallwayMap;
    [SerializeField] private GameObject PitMap;
    [SerializeField] private Transform ObstacleParent;
    [SerializeField] private GameObject BottomObstacle;
    [SerializeField] private GameObject TopObstacle;
    [SerializeField] private Transform SpikesParent;
    [SerializeField] private GameObject Spikes;

    public float playerHealth;

    GameObject[] maps = new GameObject[3];
    GameObject[] obstacles = new GameObject[2];

    ///
    /// 
    ///
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMat.color = Color.grey;

        maps[0] = BasicMap;
        maps[1] = HallwayMap;
        //maps[2] = PitMap;

        obstacles[0] = BottomObstacle;
        obstacles[1] = TopObstacle;

        playerHealth = 100f;

        //Instantiate(spotLightBG, transform.position, Quaternion.identity);
    }

    void Update()
    {
        Movement();
        ObjectInstantiation();
        RocketLauncher();

        Debug.Log(playerHealth);
    }

    Vector3 lastPosition = new Vector3();
    public float speedCap = 10f;
    float speedIncrement = 3f;
    void Movement()
    {
        //float timer = 0f;
        float speed = Vector3.Distance(lastPosition, transform.position) * 100f;

        lastPosition = transform.position;

        if (speedCap < 80)
        {
            speedCap += speedIncrement * Time.deltaTime;
        }

        if (speed<=speedCap)
        {
            rb.velocity += transform.right * Time.deltaTime * movementSpeed;
        }

        //Debug.Log(speedCap);
    }

    float positionCount;
    float positionCountBG;
    float BGInitialCount = 0;
    void ObjectInstantiation()
    {

        // if (playerPos.x >= positionCount)
        // {
        //     Vector3 spotlightPos = new Vector3(positionCount + 50, 8f, 4.3f);

        //     positionCount += 50;

        //     GameObject spotLight = Instantiate(spotLightBG, spotlightPos, Quaternion.Euler(57, 0, 0), spotLightParent);
        // }



        //spawning map

        Vector3 playerPos = transform.position;
        
        if (playerPos.x >= positionCountBG-50)
        {
            Vector3 backgroundPos = new Vector3(positionCountBG + 30, 1.7f, -0.4f);

            positionCountBG += 50;

            int randomBG = Random.Range(0,2);

            if (BGInitialCount == 0)
            {
                GameObject initalBackground = Instantiate(BasicMapNotBaked, backgroundPos, Quaternion.Euler(0,0,0), MapParent);
                
                BGInitialCount = 1;
            }
            else
            {
                GameObject background = Instantiate(maps[randomBG], backgroundPos, Quaternion.Euler(0,0,0), MapParent);
            }



            int chanceOfObstacle = Random.Range(0,2);

            if (chanceOfObstacle == 0)
            {
                Debug.Log("obstacle");

                //spawning obstacle
                Vector3 topObstaclePos = backgroundPos;

                topObstaclePos.y = 3.608f;
                
                Vector3 bottomObstaclePos = backgroundPos;

                bottomObstaclePos.y = -1.423f;
                if (randomBG == 1)
                {
                    GameObject obstacle = Instantiate(TopObstacle, topObstaclePos, Quaternion.identity, ObstacleParent);
                }
                else
                {
                    int ObstacleSelect = Random.Range(0,2);

                    if (ObstacleSelect == 1)
                    {
                        GameObject obstacle = Instantiate(TopObstacle, topObstaclePos, Quaternion.identity, ObstacleParent);
                    } 
                    else
                    {
                        GameObject obstacle = Instantiate(BottomObstacle, bottomObstaclePos, Quaternion.identity, ObstacleParent);
                    }
                }
            }
            else if (chanceOfObstacle == 1)
            {
                Debug.Log("spikes");
                //spawning spikes
                Vector3 topSpikesPos = backgroundPos;

                topSpikesPos.y = 5.33f;
                topSpikesPos.z = 0.18f;
                
                Vector3 bottomSpikesPos = backgroundPos;

                bottomSpikesPos.y = -3.15f;
                bottomSpikesPos.z = 0.18f;

                if (randomBG == 1)
                {
                    GameObject obstacle = Instantiate(Spikes, topSpikesPos, Quaternion.identity, SpikesParent);
                }
                else
                {
                    int SpikesSelect = Random.Range(0,2);

                    if (SpikesSelect == 1)
                    {
                        GameObject obstacle = Instantiate(Spikes, topSpikesPos, Quaternion.identity, SpikesParent);
                    }
                    else
                    {
                        GameObject obstacle = Instantiate(Spikes, bottomSpikesPos, Quaternion.identity, SpikesParent);
                    }
                }

            }
        }


        


    }
    Vector3 lastPositionRocket = new Vector3();

    void RocketLauncher()
    {
        Vector3 RLdirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(RLdirection.y, RLdirection.x) *Mathf.Rad2Deg;

        rocketLauncher.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

        //Firing the launcher
        if (Input.GetMouseButtonDown(0))
        {
            rocketLauncherRotation = rocketLauncher.rotation;
            GameObject rocket = Instantiate(RocketPrefab, rocketLauncher.position + rocketLauncher.right*1.4f, rocketLauncherRotation, rockets);

            Rigidbody rb = rocket.GetComponent<Rigidbody>();
            float speed = Vector3.Distance(lastPositionRocket, transform.position) * 100f;
            rb.AddForce(rocket.transform.right * (initialRocketPropulsion+speed*0.4f) );
            lastPositionRocket = transform.position;
        }


    }



}


