using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    public GameObject ExplosionEffect;

    void Start()
    {
        explodeGoat();
    }

    public void explodeGoat()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Debug.Log("Goat have left the game :(");
    }
}
