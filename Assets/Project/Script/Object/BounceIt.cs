using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceIt : MonoBehaviour
{
    public int force;
    public Rigidbody rigidbodyE;

    void Start()
    {
        force = 3;
        rigidbodyE.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EasterEgg")
        {
            rigidbodyE.AddForce(Vector3.up * force);
        }
    }
}
