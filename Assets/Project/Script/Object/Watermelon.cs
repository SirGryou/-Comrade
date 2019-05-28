using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public GameObject ExplosionEffect;


    void Start()
    {
        explodewatermelons();
    }

   public void explodewatermelons()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Debug.Log("Watermelon splotch !");

    }
}
