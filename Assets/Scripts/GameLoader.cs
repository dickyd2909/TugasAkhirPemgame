using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLoader : MonoBehaviour
{

    public string saveDirectory = "Saves";
    public string saveName = "SavedGame";
    public GameObject loadingScreens;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    public void LoadFromFile (int sceneIndex) {
        //Convert binary file back into readable data for unity game
        BinaryFormatter formatter = new BinaryFormatter();

        //choosing the saved file to open
        FileStream saveFile = File.Open(saveDirectory + "/" + saveName + ".bin", FileMode.Open);

        //convert the file data into saveGameData format for use in game
        PlayerData loadData = (PlayerData) formatter.Deserialize(saveFile);

        //print all of data
        print("Loaded Game Data");
        print("player position : " + loadData.position );
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    
        saveFile.Close();
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
