using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExplosiveBarrel : MonoBehaviour
{
    public float radius = 5f;
    public float force = 500f;

    public bool wasExplodedfor;



    public GameObject explosionEffectn1;
    public GameObject explosionEffectn2;

    public void Update()
    {
        ExplodeBarrel();

    }

    public void ExplodeBarrel()
    {
        
            Instantiate(explosionEffectn1, transform.position, transform.rotation);
            Instantiate(explosionEffectn2, transform.position, transform.rotation);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            FindObjectOfType<AudioManager>().Play("BoomFromBarrels");
            Debug.Log("Boom from Barrel");
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
