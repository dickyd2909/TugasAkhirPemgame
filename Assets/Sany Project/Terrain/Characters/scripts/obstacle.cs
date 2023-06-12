using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private GameObject player;
    GameObject scoring;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Obstacle"){
            // scoring.GetComponent<movement>().score +=10 ;
            Debug.Log(scoring); 
        }
    }
}
