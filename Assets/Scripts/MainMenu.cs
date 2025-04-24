using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;


public class Menu : MonoBehaviour
{
    [SerializeField] private Button firstSelectedButton;
    [SerializeField] private GameObject Soundtrack;
    [SerializeField] private AudioMixerGroup normalMixer;
    [SerializeField] private GameObject HighScoreText;

    void Start()
    {
        firstSelectedButton.Select();

        AudioSource soundtrackAudioSource = Soundtrack.GetComponent<AudioSource>();

        soundtrackAudioSource.outputAudioMixerGroup = normalMixer;
      
        DontDestroyOnLoad(Soundtrack);

        int HighScore = PlayerPrefs.GetInt("HighScore",0);

        if (HighScore != 0)
        {
            string HighScoreTextValue = $"{HighScore} pts"; 
            HighScoreText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(HighScoreTextValue);
        }
        
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
