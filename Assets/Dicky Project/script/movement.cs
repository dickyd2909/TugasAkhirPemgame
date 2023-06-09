using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float kecepatan = 7f;
    [SerializeField] TextMeshProUGUI _nScore;
    [SerializeField] TextMeshProUGUI _nHighScore;
    public GameObject player;
    private CharacterController carkon;
    private GameObject textobj;
    private float  highscore;
    [SerializeField] public int score = 0;
    SceneLoader sl;

    public bool tes;
    // Start is called before the first frame update
    void Start()
    {
        carkon = player.GetComponent<CharacterController>();
        score = 0;
        Debug.Log(score);
        _nScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        _nHighScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
        sl = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        if(PlayerPrefs.GetInt("stat") == 1){
            PlayerPrefs.SetInt("stat", 0);
            textobj = GameObject.Find("TextScore");
            textobj.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score",0).ToString();
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle")
        {
            kena();
        }
    }

    public void kena(){
        score += 10;
        _nScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            _nHighScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
    }
}
