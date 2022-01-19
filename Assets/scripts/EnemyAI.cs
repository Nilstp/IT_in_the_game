using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;
    public int health;
    public int despawnTime = 3;

    public HealthBar healthBar;

    NavMeshAgent nm;
    public Transform target;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        nm.SetDestination(target.position);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        if (health<= 0)
        {
            StartCoroutine(death());
            //Die();
        }
    }

    IEnumerator death()
    {
        animator.SetTrigger("Death");
        nm.isStopped = true;
        nm.velocity = Vector3.zero;
        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<CapsuleCollider>());
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
