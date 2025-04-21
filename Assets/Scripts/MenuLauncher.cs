using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLauncher : MonoBehaviour
{
    void Update()
    {
                transform.Rotate(90f * Time.deltaTime * 0.3f, 180f * Time.deltaTime * 0.1f, 270f * Time.deltaTime * 0.1f);
    }
}
