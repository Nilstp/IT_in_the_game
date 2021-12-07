using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    float playerHealth;

    [SerializeField]
    float timeUntillRegen;


    [SerializeField]
    float timer;
    void Start()
    {

    }



    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (playerHealth != 2)
                playerHealth = 2;
        }
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("verev");
        if (collision.transform.tag.Equals("enemy"))
        {
            timer = timeUntillRegen;
            playerHealth -= 1;
            if (playerHealth < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
