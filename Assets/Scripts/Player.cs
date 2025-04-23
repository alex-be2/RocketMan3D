using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

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
    //Maps
    [SerializeField] private Transform MapParent;
    [SerializeField] private GameObject BasicMap;
    [SerializeField] private GameObject BasicMapNotBaked;
    [SerializeField] private GameObject HallwayMap;
    [SerializeField] private GameObject PitMap;
    [SerializeField] private GameObject LavaMap;
    [SerializeField] private GameObject BasicMapCage;
    
    //Obstacles Spikes Towers
    [SerializeField] private Transform ObstacleParent;
    [SerializeField] private GameObject BottomObstacle;
    [SerializeField] private GameObject TopObstacle;
    [SerializeField] private Transform SpikesParent;
    [SerializeField] private GameObject Spikes;
    [SerializeField] private Transform TowerParent;
    [SerializeField] private GameObject Tower;
    [SerializeField] private GameObject PlankTower;
    //Pause Menu
    [SerializeField] private GameObject PauseCanvas;
    private bool isPaused;

    //player health
    [SerializeField] private Image HealthDisplay;
    [SerializeField] private GameObject DeadCanvas;
    public float playerHealth;
    private bool isDead;

    //Pick Ups
    [SerializeField] private GameObject PickUpOneGameObject;
    [SerializeField] private GameObject PickUpTwoGameObject;
    [SerializeField] private Transform PickUpParent;

    //Points
    [SerializeField] private GameObject PointsText;
    public int totalPoints;
    public float speedPoints;

    //Ammo
    [SerializeField] private GameObject AmmoText;
    public int ammo;

    //soundtrack
    [SerializeField] private AudioMixerGroup lowpassMixer;
    [SerializeField] private AudioMixerGroup normalMixer;
    [SerializeField] private GameObject Soundtrack;
    AudioSource soundtrackAudioSource; 



    GameObject[] maps = new GameObject[5];
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
        maps[2] = LavaMap;
        maps[3] = BasicMapCage;
        maps[4] = PitMap;

        obstacles[0] = BottomObstacle;
        obstacles[1] = TopObstacle;

        playerHealth = 100f;

        totalPoints = 0;

        ammo = 100;

        Time.timeScale = 1.0f;

        Soundtrack = GameObject.Find("Soundtrack");

        soundtrackAudioSource = Soundtrack.GetComponent<AudioSource>();
        soundtrackAudioSource.outputAudioMixerGroup = normalMixer;
    }

    void Update()
    {
        KeyPause();
        UpdateSoundtrack();
        ObjectInstantiation();
        if(isPaused){return;}
        Movement();
        RocketLauncher();
        HealthManagement();
        CalculatePoints();
        StartCoroutine(SlideBackAvoidance());
        // SlideBackAvoidance();
        AmmoText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(ammo);
    }

    void UpdateSoundtrack()
    {
        if (Soundtrack != null)
        {
            if (!isPaused && !isDead)
            {
                soundtrackAudioSource.outputAudioMixerGroup = normalMixer;
            }
        }
    }

    Vector3 lastPositionPoints = new Vector3();
    void CalculatePoints()
    {
        speedPoints = (Vector3.Distance(lastPositionPoints, transform.position) * 100f)/10;

        lastPositionPoints = transform.position;

        totalPoints += Convert.ToInt32(speedPoints);
        
        PointsText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(totalPoints);

    } 

    public void ReloadScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    Vector3 lastPositionSlideBack = new Vector3();

    IEnumerator SlideBackAvoidance()
    {
        Vector3 movementDirection = (transform.position - lastPositionSlideBack).normalized;

        lastPositionSlideBack = transform.position;

        //Debug.Log(movementDirection);

        if (movementDirection.x < 0)
        {
            Debug.Log("reverse");
            yield return new WaitForSecondsRealtime(0.1f); 
            speedCap = 9f;
        }
    }

    void HealthManagement()
    {
        HealthDisplay.fillAmount = Mathf.Lerp(HealthDisplay.fillAmount, playerHealth / 100 , 0.1f);
        if (playerHealth <= 0)
        {
            isDead = true;
            DeadCanvas.SetActive(true);
            if (Soundtrack != null)
            {
                soundtrackAudioSource.outputAudioMixerGroup = lowpassMixer;
            }


            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.1f);
            // Time.timeScale = 0;
        }
        else
        {
            isDead = false;
        }

        //playerMat.color = Color.Lerp(playerMat.color, Color.red, 1/playerHealth * Time.deltaTime * 10);

    }

    void KeyPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
            Pause();
        }
    }
    public void Pause()
    {
        if (Soundtrack != null)
        {
            soundtrackAudioSource.outputAudioMixerGroup = lowpassMixer;
        }

        isPaused = !isPaused;
        PauseCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0.05f : 1.0f;
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
        //spawning map

        Vector3 playerPos = transform.position;

        if (playerPos.x >= positionCountBG-50)
        {
            Vector3 backgroundPos = new Vector3(positionCountBG + 30, 1.7f, -0.4f);

            positionCountBG += 50;

            int randomBG = UnityEngine.Random.Range(0,5);

            if (BGInitialCount == 0)
            {
                GameObject initalBackground = Instantiate(BasicMapNotBaked, backgroundPos, Quaternion.Euler(0,0,0), MapParent);

                BGInitialCount = 1;
            }
            else
            {
                GameObject background = Instantiate(maps[randomBG], backgroundPos, Quaternion.Euler(0,0,0), MapParent);
            }



            int chanceOfObstacle = UnityEngine.Random.Range(0,3);

            if (chanceOfObstacle == 0)
            {
                //Debug.Log("obstacle");

                //spawning obstacle
                Vector3 topObstaclePos = backgroundPos;

                topObstaclePos.y = 3.608f;

                Vector3 bottomObstaclePos = backgroundPos;

                bottomObstaclePos.y = -1.423f;
                if (maps[randomBG] == PitMap)
                {
                    //GameObject obstacle = Instantiate(TopObstacle, topObstaclePos, Quaternion.identity, ObstacleParent);
                }
                else if(maps[randomBG] == LavaMap){}
                else
                {
                    int ObstacleSelect = UnityEngine.Random.Range(0,2);

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
                //Debug.Log("spikes");
                //spawning spikes
                Vector3 topSpikesPos = backgroundPos;

                topSpikesPos.y = 5.33f;
                topSpikesPos.z = 0.18f;

                Vector3 bottomSpikesPos = backgroundPos;

                bottomSpikesPos.y = -3.15f;
                bottomSpikesPos.z = 0.18f;

                if (maps[randomBG] == PitMap || maps[randomBG] == LavaMap)
                {
                    GameObject obstacle = Instantiate(Spikes, topSpikesPos, Quaternion.identity, SpikesParent);
                }
                else
                {
                    int SpikesSelect = UnityEngine.Random.Range(0,2);

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
            else if (chanceOfObstacle == 2)
            {
                //spawing destructable towers

                int chanceOfTower = UnityEngine.Random.Range(0,2);

                if (chanceOfTower == 1)
                {
                    Vector3 TowerPos = backgroundPos;
                    TowerPos.y = -2.089f;
                    TowerPos.z += 0.3f;

                    if (maps[randomBG] == PitMap || maps[randomBG] == LavaMap){}
                    else
                    {
                        GameObject tower = Instantiate(Tower, TowerPos, Quaternion.identity, TowerParent);
                    }
                }
                else
                {
                    Vector3 PlankTowerPos = backgroundPos;
                    PlankTowerPos.y = -1.1f;
                    PlankTowerPos.z += 0.3f;

                    if (maps[randomBG] == PitMap || maps[randomBG] == LavaMap){}
                    else
                    {
                        GameObject tower = Instantiate(PlankTower, PlankTowerPos, Quaternion.identity, TowerParent);
                    }
                }

            }

            Vector3 PickUpOnePos = backgroundPos;
            PickUpOnePos.y = UnityEngine.Random.Range(-2,4);
            PickUpOnePos.x = UnityEngine.Random.Range(backgroundPos.x-15,backgroundPos.x+15);

            // Vector3 PickUpTwoPos = backgroundPos;
            // PickUpTwoPos.y = UnityEngine.Random.Range(-2,4);
            // PickUpTwoPos.x = UnityEngine.Random.Range(backgroundPos.x-15,backgroundPos.x+15);

            GameObject PickUpOne = Instantiate(PickUpOneGameObject, PickUpOnePos, Quaternion.identity, PickUpParent);
            // GameObject PickUpTwo = Instantiate(PickUpTwoGameObject, PickUpTwoPos, Quaternion.identity, PickUpParent);
        }





    }
    Vector3 lastPositionRocket = new Vector3();

    void RocketLauncher()
    {
        if (Time.timeScale >= 0.1f)
        {
            Vector3 RLdirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

            float angle = Mathf.Atan2(RLdirection.y, RLdirection.x) *Mathf.Rad2Deg;

            rocketLauncher.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

            //Firing the launcher
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log(ammo);
                if (ammo > 0)
                {
                    ammo -= 1;
                    AmmoText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(ammo);
                    rocketLauncherRotation = rocketLauncher.rotation;
                    GameObject rocket = Instantiate(RocketPrefab, rocketLauncher.position + rocketLauncher.right*1.4f, rocketLauncherRotation, rockets);

                    Rigidbody rb = rocket.GetComponent<Rigidbody>();
                    float speed = Vector3.Distance(lastPositionRocket, transform.position) * 100f;
                    rb.AddForce(rocket.transform.right * (initialRocketPropulsion+speed*0.4f) );
                    lastPositionRocket = transform.position;
                }
            }
        }
    }



}


