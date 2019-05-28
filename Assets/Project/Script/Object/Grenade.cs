using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class Grenade : MonoBehaviour
{
    public float delay = 1f;
    public float delayEndGame = 1f;
    public float radius = 2f;
    public float force = 200f;

    public GameObject explosionEffect;

    float countdown;
    public bool hasExploded = false;

  
    void Start()
    {
        countdown = delay;
        
    }

   
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            
            hasExploded = true;
        }
    }


    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("Boom");
        CameraShaker.Instance.ShakeOnce(2f, 2f, .2f, 2f);
        FindObjectOfType<AudioManager>().Play("Grenade"); 

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);

    }

}
