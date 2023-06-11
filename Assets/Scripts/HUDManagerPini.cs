using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManagerPini : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

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

    public void SaveGame () {
        SaveSystem.SavePlayer(playerInstance);
    }
}
