using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDébris : MonoBehaviour
{
    public AudioSource debritSound;

  
    void Start()
    {
        debritSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            debritSound.Play();
            //Destroy(collision.gameObject);
            Destroy(this);
        }
    }
}
