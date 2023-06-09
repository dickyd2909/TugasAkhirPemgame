using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGuns : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce;
    public float timeBeetweenShooting, spread, reloadTime,timeBetweenShots;
    public int magazineSize, bulletPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attacctPoint;
    public bool allowInvoke = true;

    private void Awake(){
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update(){
        MyInput();
    }

    private void MyInput(){
        if(allowButonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);
    }


}
