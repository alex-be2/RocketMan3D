using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Material playerMat;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(0.001f,0,0);
    }

    private void OnTriggerStay(Collider other)
    {
        playerMat.color = Color.Lerp(playerMat.color, Color.red, 0.5f * Time.deltaTime);
    }
}
