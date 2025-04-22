using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestructableTower : MonoBehaviour
{
    // [SerializeField] private GameObject player;
    // [SerializeField] private GameObject rocket;
    [SerializeField] private Material DefaultRed;
    [SerializeField] private Material HitGreen;
    
    //cubes
    [SerializeField] private GameObject cube01;
    [SerializeField] private GameObject cube02;
    [SerializeField] private GameObject cube03;
    [SerializeField] private GameObject cube04;
    [SerializeField] private GameObject cube05;
    [SerializeField] private GameObject cube06;

    List<GameObject> cubes = new List<GameObject>();
    private float timer = 0.5f;


    void Start()
    {
        // player = GameObject.Find("Player");
        // rocket = GameObject.Find("Rocket");

        cubes.Add(cube01);
        cubes.Add(cube02);
        cubes.Add(cube03);
        cubes.Add(cube04);
        cubes.Add(cube05);
        cubes.Add(cube06);

    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 currentPos = transform.position;
        if (player.transform.position.x - currentPos.x > 50)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (playerCollider == other)
        {
            //Debug.Log("green");
            //Debug.Log(Time.timeScale);


            Time.timeScale = Mathf.Lerp(1.0f, 0.2f, 5.0f);

            timer -= Time.deltaTime;
            
            Debug.Log(timer );
            if (timer < 0.5f)
            {
            Time.timeScale = Mathf.Lerp(0.2f, 1.0f, 5.0f);
            }
        }

    }
}
