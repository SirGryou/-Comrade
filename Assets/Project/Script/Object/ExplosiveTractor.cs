using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExplosiveTractor : MonoBehaviour
{
    public float radius = 8f;
    public float force = 1000f;

    public bool wasExplodedfor;

    public GameObject explosionEffect;

    void Update()
    {
        ExplodeLevePalette();
    }

    public void ExplodeLevePalette()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        CameraShaker.Instance.ShakeOnce(5f, 5f, .2f, 2f);
        FindObjectOfType<AudioManager>().Play("LevelPalette");
        Debug.Log("Boom from little car !");
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
                Destroy(this);
            }
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                Destroy(this);
            }
        }
    }
}
