using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public float health = 50f;

    NavMeshAgent nm;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nm.SetDestination(target.position);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
