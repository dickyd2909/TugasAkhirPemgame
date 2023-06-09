using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreens;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;
    public static bool loadStatus;

    public void loadlevel (int sceneIndex) {
        
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            int progress = (int)Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            loadingText.text = progress  * 100 + "%";

            yield return null;

        }
    }
}
