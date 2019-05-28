using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;

    void OnCollisionEnter (Collision collision)
	{
        if (collision.gameObject.name == "Sphere")
        {
            ScoreTextScript.cashAmount += 50;
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
    public void Destroy()
    {
        ScoreTextScript.cashAmount += 50;
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
