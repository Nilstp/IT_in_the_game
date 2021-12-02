using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    float playerHealth;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("enemy")) {
            playerHealth -= 1;
            if (playerHealth < 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
