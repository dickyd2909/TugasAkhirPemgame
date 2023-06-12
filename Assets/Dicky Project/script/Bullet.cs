using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3;
    GameObject scoring;
    int score;
 
    void Awake()
    {
        //Destroy(gameObject, life);
        score = 0;
    }
 
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle")
        {
           Destroy(other.gameObject);
           Destroy(gameObject);
        }
    }

    // public float life = 3;
    // private GameObject textobj;
    // private GameObject textHigh;
    // private int score;
    // private GameObject tes;
    // void Awake()
    // {
    //     Destroy(gameObject, life);
        
    // }

    // private void Start() {
    //     textHigh = GameObject.Find("TextHigh");
    //     textobj = GameObject.Find("TextScore");
    //     textobj.GetComponent<TextMeshProUGUI>().text = score.ToString();
    //     textHigh.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
    // }

    // private void Update() {
    //     score = score + 10;
    // }
   
    // private void OnTriggerEnter(Collider other) {
    //     if(other.tag == "Obstacle")
    //     {
    //         Destroy(other.gameObject);
    //         Destroy(gameObject);
    //         kena();
    //     }
    // }

    // private void kena(){
    //     score += 10;
    //     Debug.Log(score);
    //     textobj = GameObject.Find("TextScore");
    //     textobj.GetComponent<TextMeshProUGUI>().text = score.ToString();
    //     if(score > PlayerPrefs.GetInt("HighScore",0))
    //     {
    //         PlayerPrefs.SetInt("HighScore", score);
    //         textHigh.GetComponent<TextMeshProUGUI>().text = score.ToString();
    //     }
    // }
}
