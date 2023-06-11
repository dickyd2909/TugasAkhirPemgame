using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animasi : MonoBehaviour
{
    //variable kecepatan
    private float kecepatan_player;
    public float nilai_x;
    public float nilai_z;
    private bool status_ground;


    //referensi
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        nilai_x = player.GetComponent<movement>().x;
        nilai_z = player.GetComponent<movement>().z;
        // status_ground = player.GetComponent<movement>().isGround;
        // kecepatan_player = player.GetComponent<movement>().speed;

        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("IsGrounded", status_ground);
        anim.SetFloat("speed", kecepatan_player);

    }
}
