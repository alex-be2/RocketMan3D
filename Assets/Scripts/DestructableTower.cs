using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestructableTower : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject SlowMoText;
    [SerializeField] private GameObject SlowMoText01;
    [SerializeField] private GameObject SlowMoText02;
    [SerializeField] private GameObject SlowMoText03;
    [SerializeField] private GameObject SlowMoText04;
    [SerializeField] private GameObject SlowMoText05;

    GameObject[] prompts = new GameObject[6];

    int randomPrompt = 0;


    void Start()
    {
        player = GameObject.Find("Player");

        prompts[0] = SlowMoText;
        prompts[1] = SlowMoText01;
        prompts[2] = SlowMoText02;
        prompts[3] = SlowMoText03;
        prompts[4] = SlowMoText04;
        prompts[5] = SlowMoText05;

        randomPrompt = UnityEngine.Random.Range(0,6);



    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");

        Collider playerCollider = player.GetComponent<Collider>();

        if (playerCollider == other)
        {
            Player playerScript = player.GetComponent<Player>();

            if (playerScript.speedPoints*10 > 40)
            {
                StartCoroutine(SlowMotion());
            }
        }

    }

    IEnumerator SlowMotion()
    {
        prompts[randomPrompt].SetActive(true);
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.1f,0.9f);
        yield return new WaitForSecondsRealtime(1f); 
        Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f,0.9f);

        Destroy(gameObject);
    }


}
