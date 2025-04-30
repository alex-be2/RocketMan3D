using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLauncher : MonoBehaviour
{
    [SerializeField] private Material Red;
    [SerializeField] private Material Blue;
    [SerializeField] private Material Special;
    [SerializeField] private GameObject launcher;


    void Start()
    {
        if (gameObject.name == "LauncherRed")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Red;
            launcherRenderer.materials = mats;
        }
        if (gameObject.name == "LauncherBlue")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Blue;
            launcherRenderer.materials = mats;
        }
        if (gameObject.name == "LauncherSpecial")
        {
            SkinnedMeshRenderer launcherRenderer = launcher.GetComponent<SkinnedMeshRenderer>();
            Material[] mats = launcherRenderer.materials;

            mats[0] = Special;
            launcherRenderer.materials = mats;
        }
    }
    void Update()
    {
        transform.Rotate(-15f * Time.deltaTime,0,0);
    }
}
