using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Material collectableMat;
    [SerializeField] private Material playerMat;
    [SerializeField] private List<Color> colours = new List<Color>();

    void Start()
    {
        InvokeRepeating ("ChangeBlue", 0f, 10f);
        //InvokeRepeating("ChangeMag", 5f, 5f);
        colours.Add(Color.magenta);
        colours.Add(Color.cyan);
    }

    void Update()
    {
        transform.Rotate(90f * Time.deltaTime, 180f * Time.deltaTime, 270f * Time.deltaTime);

    }

    void ChangeBlue()
    {
        collectableMat.color = Color.Lerp(colours[Random.Range(0, colours.Count)], colours[Random.Range(0, colours.Count)], 100f * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        playerMat.color = Color.Lerp(playerMat.color, Color.green, 5f * Time.deltaTime);
        //green.color = Color.white;
    }
}