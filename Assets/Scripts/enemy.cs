using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private Material playerMat;

    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        playerMat.color = Color.Lerp(playerMat.color, Color.red, 0.5f * Time.deltaTime);
    }
}
