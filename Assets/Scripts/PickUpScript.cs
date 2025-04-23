using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private GameObject PickUpParent;
    [SerializeField] private GameObject InsideCube;
    [SerializeField] private Material green;
    [SerializeField] private Material red;
    [SerializeField] private Material blue;
    [SerializeField] private Material yellow;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject SlowMoText;

    [SerializeField] private GameObject ExtraPoints;
    [SerializeField] private GameObject ExtraAmmo;

    Material[] mats = new Material[4];
    int randomMat;

    void Start()
    {
        player = GameObject.Find("Player");

        mats[0] = green;
        mats[1] = red;
        mats[2] = blue;
        mats[3] = yellow;
        randomMat = UnityEngine.Random.Range(0,4);

        Material chosenMat = mats[randomMat];

        InsideCube.GetComponent<MeshRenderer>().material = chosenMat;

    }

    void OnTriggerEnter(Collider other)
    {
        // GameObject player = GameObject.Find("Player");
        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            switch(randomMat)
            {
                case 0:
                //green is points
                StartCoroutine(GreenPoints());
                break;
                case 1:
                //red is health
                RedHealth();
                break;
                case 2:
                //blue is slow motion
                StartCoroutine(BlueSlowMotion());     
                break;
                case 3:
                //yellow is increase ammo
                StartCoroutine(YellowInceaseAmmo());
                break;
            }
        }       
    }

    IEnumerator GreenPoints()
    {
        ExtraPoints.SetActive(true);

        HidePickUp();

        yield return new WaitForSecondsRealtime(3f); 

        Player playerScript = player.GetComponent<Player>();

        playerScript.totalPoints += 2500;

        Destroy(PickUpParent);
    }
    void RedHealth()
    {
        float health = player.GetComponent<Player>().playerHealth;
        //Debug.Log("Redfunc");

        if(health < 100)
        {
            player.GetComponent<Player>().playerHealth = 100;
        }
        Destroy(PickUpParent);
    }
    IEnumerator BlueSlowMotion()
    {
        SlowMoText.SetActive(true);

        HidePickUp();

        //Need to use this as the function is not in update() and so can't use simple timer
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.1f,0.9f);
        yield return new WaitForSecondsRealtime(1f); 
        Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f,0.9f);
        Debug.Log("out");

        Player playerScript = player.GetComponent<Player>();

        playerScript.totalPoints += 5000;

        Destroy(PickUpParent);
    }
    IEnumerator YellowInceaseAmmo()
    {
        ExtraAmmo.SetActive(true);

        HidePickUp();
        
        Player playerScript = player.GetComponent<Player>();

        playerScript.ammo += 5;

        yield return new WaitForSecondsRealtime(3f); 
        Destroy(PickUpParent);
    }

    void HidePickUp()
    {
        InsideCube.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

}
