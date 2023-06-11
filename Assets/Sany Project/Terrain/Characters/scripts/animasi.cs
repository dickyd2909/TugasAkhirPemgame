// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class animasi : MonoBehaviour
// {
//     private float kecepatan_player;
//     public float nilai_x;
//     public float nilai_z;
//     private bool status_ground;

//     private Animator anim;
//     private GameObject player;

//     // Start is called before the first frame update
//     void Start()
//     {
//         anim = GetComponentInChildren<Animator>();
//         player = GameObject.Find("Player");
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         nilai_x = player.GetComponent<pergerakan_player>().x;
//         nilai_z = player.GetComponent<pergerakan_player>().z;
//         status_ground = player.GetComponent<pergerakan_player>().isGrounded;
//         // kecepatan_player =  player.GetComponent<pergerakan_player>().kecepatan;
//         anim.SetFloat("x",nilai_x);
//         anim.SetFloat("z", nilai_z);
//         anim.SetBool("isGrounded", status_ground);
//         // anim.SetFloat("speed", kecepatan_player);
//     }
// }