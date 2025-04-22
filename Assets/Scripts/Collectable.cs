using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Material collectableMat;
    [SerializeField] private Material playerMat;
    [SerializeField] private List<Color> colours = new List<Color>();
    [SerializeField] private Renderer collectableRenderer;

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

    private void OnTriggerEnter(Collider other)
    {
        collectableRenderer.enabled = false;
        gameObject.AddComponent<Light>();

        Light light = gameObject.GetComponent<Light>();
        
        light.intensity = 2;
        light.color = Color.green;
        light.range = 5;
    }
    private void OnTriggerExit(Collider other)
    {
        //renderer.enabled = true;
    }
}