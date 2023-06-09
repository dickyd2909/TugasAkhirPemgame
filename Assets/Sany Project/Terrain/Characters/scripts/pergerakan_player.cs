using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pergerakan_player : MonoBehaviour
{
    ///VARIABEL////

    
    //MOVEMENT
    [SerializeField] public float kecepatan;
    public float x;
    public float z;

    //LOMPAT
    [SerializeField] private float speed_jump = 1f;

    //JALAN
    [SerializeField] private float speed_jalan = 4f;
    [SerializeField] public float speed_lari = 7f;

    //GRAVITASI
    [SerializeField] private float gravitasi = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGrounded;
    Vector3 velocity;



    //REFERENSI
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        bergerak();
        lompat();
        jalan();
    }

    private void bergerak()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerakan = transform.right * x + transform.forward * z;
        controller.Move(gerakan * kecepatan * Time.deltaTime);
    }

    private void gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void lompat()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(speed_jump * -2f * gravitasi);
        }

    }

    private void jalan()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            kecepatan = speed_jalan;
        }
        else
        {
            kecepatan = speed_lari;
        }
        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
