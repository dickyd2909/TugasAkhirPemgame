using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    // public static bool loadStatus;
    // public Player playerInstance;
    // public GameObject loadingScreens;
    // public Slider loadingBar;
    // public TextMeshProUGUI loadingText;
    void Start()
    {
        if(SceneLoader.loadStatus)
        {
            LoadPlayer();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        // EnviroSky.instance.SetTime(1, 1, data.time[0], data.time[1], data.time[2]);
        transform.position = position;


    }
    // IEnumerator LoadAsync(int sceneIndex)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    //     while(!operation.isDone)
    //     {
    //         int progress = (int)Mathf.Clamp01(operation.progress / .9f);
    //         loadingBar.value = progress;
    //         loadingText.text = progress  * 100 + "%";

    //         yield return null;

    //     }
    // }
}
