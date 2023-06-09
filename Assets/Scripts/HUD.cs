using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HUD : MonoBehaviour
{
    public float health;
    public string info;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            Debug.Log("Player is Alive!");
        }
        else
        {
            Debug.Log("Player Died!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            health -= 30f;
            Debug.Log("Health = " + health);
            info = "U was trying to eat an poisonous mushroom";
        }

        if (other.tag == "Enemy")
        {
            health -= 40f;
            Debug.Log("Health = " + health);
            info = "U was killed by virus";
        }
    }
}
