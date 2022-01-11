using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject bananaPistol;
    public bool isFiring = false;
    public float fireRate = 15f;

    void Update()
    {
        if (Input.GetButton("Fire1")) 
        {
            if(isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }
    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        bananaPistol.GetComponent<Animator>().Play("fireGun");
        yield return new WaitForSeconds(1f / fireRate);
        bananaPistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
