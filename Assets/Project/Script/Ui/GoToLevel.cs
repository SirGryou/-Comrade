using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        ScoreTextScript.cashAmount = 0;
        GrenadeUI.grenadeAmount = 0;
    }
}
