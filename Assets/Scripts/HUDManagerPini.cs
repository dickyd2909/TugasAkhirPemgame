using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDManagerPini : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public GameObject loadingScreens;

    public Slider loadingBar;
    public TextMeshProUGUI loadingText;
    public static bool loadStatus;

    public static bool GameIsPaused = false;
    public Player playerInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowPauseMenu();
    }

    private void ShowPauseMenu () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SaveGame (int sceneIndex) {
        SaveSystem.SavePlayer(playerInstance);
        
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = true;
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
