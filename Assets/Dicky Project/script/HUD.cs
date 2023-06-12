using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDMaca : MonoBehaviour
{
    public Image currentEnergy;

    public static bool GameIsPaused;    
    public Player playerInstance;

    
    private float energy = 200;
    private float maxEnergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;
    private GameObject player;

    //Health System
    private float health;
    private float maxhealth = 100f;
    public Image currentHealth;
    string info;

    //Game Over
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject information;
    [SerializeField] TextMeshProUGUI pesan;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = player.GetComponent<pergerakan_player>().speed_lari;

        GameIsPaused = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<pergerakan_player>().kecepatan;
        input_x = player.GetComponent<pergerakan_player>().x;
        input_z = player.GetComponent<pergerakan_player>().z;
        health = player.GetComponent<sistem_darah>().darah_player;
        info = player.GetComponent<sistem_darah>().info;
        pesan.GetComponent<TextMeshProUGUI>().text = info;

        EnergyDrain();
        UpdateEnergy();
        UpdateHealth();
        gameOver();
        // restart();

    }

    private void EnergyDrain()
    {

        if (kecepatan == kecepatanLari)
        {
            if (input_x > 0 || input_z > 0)
            {
                if(energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }
            }
                
        }
        else
        {
            if(energy < maxEnergy) {
                energy += 10 * Time.deltaTime;
            }
            
        }

        
    }

    private void UpdateEnergy()
    {
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateHealth()
    {
        float ratio = health / maxhealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void gameOver()
    {
        if (health < 1)
        {
            //player mati
            GameOverMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    // public void restart()
    // {
    //     SceneManager.LoadScene("MainGame");
    // }
}
