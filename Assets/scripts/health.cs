using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Text maxHealthText;
    public Text currentHealthText;

    [SerializeField]
    public int playerHealth;
    public int maxHealth = 100;

    public HealthBar healthBar;

    [SerializeField]
    float timeUntillRegen;


    [SerializeField]
    float timer;



    void Start()
    {
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    void Update()
    {

        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = playerHealth.ToString();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (playerHealth != 100) 
            {
                playerHealth = 100;
                healthBar.SetHealth(playerHealth);
            }
        }
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hit");
        if (collision.transform.tag.Equals("enemy"))
        {
            timer = timeUntillRegen;
            playerHealth -= 40;
            healthBar.SetHealth(playerHealth);
            if (playerHealth < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
