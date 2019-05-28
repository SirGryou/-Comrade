using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider sliderProgress;
    public Text progressText;
    public void LoadLevel (string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
        ScoreTextScript.cashAmount = 0;
        GrenadeUI.grenadeAmount = 0;
    }
    IEnumerator LoadAsynchronously (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            sliderProgress.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    
}
