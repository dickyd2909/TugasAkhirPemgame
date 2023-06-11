using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private GameObject player;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        if(score == 0){
            score += 10;
        }else{
            score = score;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other) 
    {
       if(other.tag == "Obstacle"){
            score += 10;
            Debug.Log(score);
       }
    }
}
