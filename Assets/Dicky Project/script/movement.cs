using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] TextMeshProUGUI _nScore;
    [SerializeField] TextMeshProUGUI _nHighScore;
    public GameObject player;
    private GameObject menCam;
    private CharacterController carkon;
    public float  highscore,x,y,z;
    private int score;
    // Start is called before the first frame update

    //MOVEMENT
    public CharacterController controller;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float ground_Distance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGround;
    Vector3 velocity;
     private float gravitasi = 20f;
    private float speed_jump = 2f;
    public float speed_lari = 100f;



    void Start()
    {
        menCam = Camera.main.gameObject;
        menCam.transform.parent = player.transform;
        menCam.transform.localPosition = new Vector3(0.27f, 2f, -2.9f);
        menCam.transform.localEulerAngles = new Vector3(11, 0, 0);
        carkon = player.GetComponent<CharacterController>();
        score = 0;
        _nScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        _nHighScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        bergerak();
        lari();
        jump();
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

    //FUNGSI MOVEMENT
      private void bergerak()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerakan = transform.right * x + transform.forward * z;
        carkon.Move(gerakan * speed * Time.deltaTime);
    }
      private void gravity()
      {
        isGround = Physics.CheckSphere(groundcheck.position, ground_Distance, groundMask);

        if(isGround && velocity.y <0){
            velocity.y = -2f;
        }
     
    }
     private void jump(){
        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(speed_jump *2f *gravitasi);
        }
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void lari()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = speed_lari;
        }
        else{
            speed = 3f;
        }
     
    }
}
