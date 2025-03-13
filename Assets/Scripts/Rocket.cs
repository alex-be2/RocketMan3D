using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float propulsion;
    //Vector3 verticalVector = new Vector3();

    [SerializeField] private float angularDrag;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject SmokePrefab;
    [SerializeField] private Transform smokeTrails;
    [SerializeField] private Transform explosions;
    [SerializeField] private GameObject sfxExplosion;

    //public Transform 



    void Start()
    {
        smokeTrails = GameObject.Find("SmokeTrails").transform;
        explosions = GameObject.Find("Explosions").transform;
    }

    void Update()
    {
        //GameObject st = GameObject.Find("SmokeTrails");


        transform.Rotate(540, 0, 0);

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.right * propulsion);

        rb.angularDrag = angularDrag;

        GameObject smoke = Instantiate(SmokePrefab, transform.position - transform.right, Quaternion.identity, smokeTrails);

        Destroy(smoke, 1.8f);

        AudioSource sfxFlying = GetComponent<AudioSource>();

        sfxFlying.pitch = Random.Range(0.5f, 1);
        //sfxFlying.volume = 1;
        if(!sfxFlying.isPlaying)
        {
            sfxFlying.Play();
        }

        Debug.Log("BOOM");


    }

    private void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 3f, ForceMode.Impulse);
            }
        }

        GameObject sfxexplosion = Instantiate(sfxExplosion, transform.position, Quaternion.identity, explosions);

        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, explosions);


        Destroy(explosion, 1.8f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
