using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button firstSelectedButton;
    [SerializeField] private GameObject Soundtrack;
    [SerializeField] private AudioMixerGroup normalMixer;

    void Start()
    {
        firstSelectedButton.Select();

        //GameObject repeatSoundtrack = GameObject.Find("Soundtrack");

        AudioSource soundtrackAudioSource = Soundtrack.GetComponent<AudioSource>();

        soundtrackAudioSource.outputAudioMixerGroup = normalMixer;
      
        DontDestroyOnLoad(Soundtrack);
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainGame");
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
