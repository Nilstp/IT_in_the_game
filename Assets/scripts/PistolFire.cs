using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject bananaPistol;
    public bool isFiring = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
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
        yield return new WaitForSeconds(0.25f);
        bananaPistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
