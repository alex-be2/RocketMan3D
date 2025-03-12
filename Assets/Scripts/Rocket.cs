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


    
    void Update()
    {
        transform.Rotate(540,0,0); 

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.right*propulsion);   

        rb.angularDrag = angularDrag;

        GameObject smoke = Instantiate(SmokePrefab, transform.position-transform.right,Quaternion.identity,smokeTrails);

        Destroy(smoke,1.8f);


    }

    private void OnTriggerStay(Collider other)
    {
        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);

        GameObject explosion = Instantiate(ExplosionPrefab, transform.position,Quaternion.identity);
        Destroy(explosion,1.8f);
        Destroy(gameObject);
    }
}
