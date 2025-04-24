using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        Player playerScript = player.GetComponent<Player>();
        gameObject.GetComponent<TextMeshProUGUI>().text = Convert.ToString(playerScript.HighScore); 
    }
}
