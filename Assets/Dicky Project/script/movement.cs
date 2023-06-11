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
    private float  highscore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        carkon = player.GetComponent<CharacterController>();
        score = 0;
        PlayerPrefs.SetInt("HighScore",0);
        _nScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        _nHighScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     bergerak();
    // }

    // private void bergerak()
    // {
    //     x = Input.GetAxis("Horizontal");
    //     z = Input.GetAxis("Vertical");
    //     Vector3 gerakan = transform.right * x + transform.forward * z;
    //     carkon.Move(gerakan * kecepatan * Time.deltaTime);
    // }

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
