using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    [SerializeField] private Button firstSelectedButton;

    // void Start()
    // {
    //     firstSelectedButton.Select();
    // }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainGame");
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
