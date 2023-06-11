using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistem_darah : MonoBehaviour
{
    public float darah_player;
    public string info;

    // Start is called before the first frame update
    void Start()
    {
        darah_player = 100f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(darah_player>0)
        {
            // Debug.Log("Player Hidup");
        }
        else
        {
            // Debug.Log("Player Mati");
            darah_player = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            darah_player -= 30;
            Debug.Log("Darah ="+ darah_player);
            info = "You was tring to eat an poisonous mushroom";
        }
        if (other.tag == "Enemy")
        {
            darah_player -= 10;
            Debug.Log("Darah =" + darah_player);
            info = "You was killed by a spider";
        }
        if (other.tag == "Fire")
        {
            darah_player -= 40;
            Debug.Log("Darah =" + darah_player);
            info = "You was burned alive";
        }
    }
}
