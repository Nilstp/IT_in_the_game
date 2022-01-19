using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool isOn = false;
    public GameObject lightSource;

    //public AudioSource clickSound;
    //public bool failSafe = false;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (lightSource.activeSelf == false)
            {
                lightSource.SetActive(true);
                Debug.Log("F pressed active");
            }
            else
            {
                Debug.Log("Q pressed deactive");
                lightSource.SetActive(false);
            }
        }
    }
}
