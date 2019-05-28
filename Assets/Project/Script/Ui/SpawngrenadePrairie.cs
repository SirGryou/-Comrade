using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawngrenadePrairie : MonoBehaviour
{
    [SerializeField]
    GameObject grenadePrefab;
    private GameObject grenadeInstance;

    private int nCurrentGrenande = 0;

    public float delay = 5f;

    public int nMaxGrenade = 5;

    public void CheckVictory()
    {
        Debug.Log("PUTE");
        if (GrenadeUI.grenadeAmount == 5 && ScoreTextScript.cashAmount >= 2000)
        {
            SceneManager.LoadScene("You Win");
        }
    }
    public void CheckLose()
    {
        Debug.Log("PUTEDEPUTE");
        if (GrenadeUI.grenadeAmount == 5 && ScoreTextScript.cashAmount <= 2000)
        {
            SceneManager.LoadScene("You Lose");
        }
    }
    public void SpawnGrenada()
    {
        Invoke("CheckVictory", delay);
        Invoke("CheckLose", delay);
        if (grenadeInstance == null || grenadeInstance.GetComponent<Grenade>().hasExploded == true)
        {
            if (nCurrentGrenande < nMaxGrenade)
            {
                nCurrentGrenande++;

                grenadeInstance = Instantiate(grenadePrefab, new Vector3(-0.57f, 5.96f, 32.96f), Quaternion.identity);
                grenadeInstance.name = grenadePrefab.name;
                GrenadeUI.grenadeAmount += 1;
            } 
        }
    }
}
