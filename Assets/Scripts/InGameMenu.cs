using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    [SerializeField] private Button firstSelectedButton;
    public void ChangeScene()
    {
        GameObject Soundtrack = GameObject.Find("Soundtrack");

        Destroy(Soundtrack);
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
