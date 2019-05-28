using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrenade : MonoBehaviour
{
    [SerializeField]
    public GameObject grenadePrefab;
    private GameObject grenadeInstance;

    private int nCurrentGrenade = 0;
    //public bool hasExploded;

    public float delay = 3f;

    public int nMaxGrenade = 5;



    public void SpawnGrenada()
    {
        if (grenadeInstance == null || grenadeInstance.GetComponent<Grenade>().hasExploded == true)
        {
            Debug.Log("Je suis la ");
            if (nCurrentGrenade < nMaxGrenade)
            {
                Debug.Log("Ici");
                nCurrentGrenade++;
                grenadeInstance = Instantiate(grenadePrefab, new Vector3(0f, 2.11f, -8.99f), Quaternion.identity);
                grenadeInstance.name = grenadePrefab.name;
                GrenadeUI.grenadeAmount += 1;

            }
        }
         
    }
}
