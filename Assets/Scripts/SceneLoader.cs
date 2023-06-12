using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreens;
    public Transform aboutTeam;
    public GameObject about;
    public List<GameObject> team = new List<GameObject>();
    public GameObject next;
    public GameObject prev;
    public GameObject close;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;
    public Player playerInstance;
    public static bool loadStatus;

    [SerializeField] int index = 0;
    [SerializeField] int currIndex = 0;


    

    void Start()
    {
        for(int i = 0; i < team.Count; i++)
        {
            GameObject go = Instantiate(team[i], aboutTeam);

            if(i>0)
            {
                go.SetActive(false);
            }
        } 
        
    }

    void update()
    {
        SaveGamePlayer();
    }
    public void LoadSaveGame (int sceneIndex) {
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = true;
    }
    public void MainMenu (int sceneIndex) {
        
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = true;
        SaveGamePlayer();
    }

    public void SaveGamePlayer () {
        
        SaveSystem.SavePlayer(playerInstance);        
        // loadingScreens.SetActive(true);
        // StartCoroutine(LoadAsync(sceneIndex));
        // loadStatus = false;
    }

    public void loadlevel (int sceneIndex) {
        
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = false;
    }
    

    public void AboutGame(){
        about.SetActive(true);
    }
    
    

    public void Next()
    {
        index++;
        currIndex = index % team.Count;
        ResetAllTeam();
        aboutTeam.GetChild(currIndex).gameObject.SetActive(true);
        
    }

    public void Prev()
    {
        index--;
        currIndex = index % team.Count;
        ResetAllTeam();
        aboutTeam.GetChild(currIndex).gameObject.SetActive(true);
        
    }

    public void Close()
    {
        about.SetActive(false);
    }
    
    void ResetAllTeam()
    {
        foreach (Transform item in aboutTeam)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void doExitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
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
