using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExplosionSound : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    [SerializeField] private AudioMixerGroup lowpassMixer;
    [SerializeField] private AudioMixerGroup normalMixer;


    void Update()
    {
        GameObject player = GameObject.Find("Player");

        float distanceToPlayer = Vector3.Distance(player.transform.position,transform.position);

        if (distanceToPlayer > 30)
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            audioSource.outputAudioMixerGroup = lowpassMixer;
        }
        if(distanceToPlayer <=30)
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            audioSource.outputAudioMixerGroup = normalMixer;
        }

        AudioSource sfxExplosion = GetComponent<AudioSource>();


        sfxExplosion.pitch = Random.Range(0.5f, 1);
        //sfxExplosion.volume = 0.2f;
        if(!sfxExplosion.isPlaying && Time.timeScale >= 0.1f)
        {
            sfxExplosion.Play();
        }
        Destroy(gameObject,1.8f);

        //Debug.Log("BOOM");   
    }
}
