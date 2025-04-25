using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MenuLauncher : MonoBehaviour
{
    [SerializeField] private Material Red;
    [SerializeField] private Material Blue;
    [SerializeField] private Material Black;
    [SerializeField] private Material Special;
    [SerializeField] private GameObject launcher;
    string launcherColour;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(15f * Time.deltaTime, 180f * Time.deltaTime * 0.1f, 270f * Time.deltaTime * 0.05f);
    
        launcherColour = PlayerPrefs.GetString("launcherColour","black");

        if (launcherColour == "black")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Black;
            launcherRenderer.materials = mats;
        }
        else if (launcherColour == "red")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Red;
            launcherRenderer.materials = mats;
        }
        else if (launcherColour == "blue")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Blue;
            launcherRenderer.materials = mats;
        }
        else if (launcherColour == "special")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Special;
            launcherRenderer.materials = mats;
        }
    }
}
