using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public float life = 3;
    // GameObject scoring;
    // int score;
 
    // void Awake()
    // {
    //     //Destroy(gameObject, life);
    //     score = 0;
    // }
 
    // private void OnTriggerEnter(Collider other) {
    //     if(other.tag == "Obstacle")
    //     {
    //        Destroy(other.gameObject);
    //        Destroy(gameObject);
    //     }
    // }
    movement move;
    public float life = 3;
    private GameObject textobj;
    private GameObject textHigh;
    private int score = 0;
    private GameObject tes;
    void Awake()
    {
        Destroy(gameObject, life);
        move = GameObject.Find("Player").GetComponent<movement>();
        // Debug.Log(move.score);
        
    }

    private void Start() {
        textHigh = GameObject.Find("TextHigh");
        textobj = GameObject.Find("TextScore");
        textobj.GetComponent<TextMeshProUGUI>().text = score.ToString();
        textHigh.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }
   
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            kena();
        }
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            kena2();
        }
    }

    private void kena(){
        move.score += 10;
        Debug.Log(move.score);
        textobj = GameObject.Find("TextScore");
        textobj.GetComponent<TextMeshProUGUI>().text = move.score.ToString();
        if(move.score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", move.score);
            textHigh.GetComponent<TextMeshProUGUI>().text = move.score.ToString();
        }
    }
    private void kena2(){
        move.score += 20;
        Debug.Log(move.score);
        textobj = GameObject.Find("TextScore");
        textobj.GetComponent<TextMeshProUGUI>().text = move.score.ToString();
        if(move.score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", move.score);
            textHigh.GetComponent<TextMeshProUGUI>().text = move.score.ToString();
        }
    }
}
