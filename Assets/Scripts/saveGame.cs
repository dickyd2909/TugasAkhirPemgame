using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class saveGame : MonoBehaviour
{
    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public PlayerData saveGameData;
    public GameObject loadingScreens;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;
    // Start is called before the first frame update

    public void SaveToFile(int sceneIndex)
    {
        // To save in a directory, it must be created first
        if (!Directory.Exists(directoryName))
        Directory.CreateDirectory(directoryName);

        //The formatter will conver our unity data type into a binary file
        BinaryFormatter formatter = new BinaryFormatter();

        //Chose the save location
        FileStream saveFile = File.Create(directoryName + saveName + ".bin");

        //write our C# Unity game data type to a binary file
        formatter.Serialize(saveFile, saveGameData);
        
        saveFile.Close();
        loadingScreens.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        //success message
        print("Game Saved to " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
