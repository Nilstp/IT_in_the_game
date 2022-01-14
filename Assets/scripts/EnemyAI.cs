using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public float health = 50f;
    public int despawnTime = 3;

    NavMeshAgent nm;
    public Transform target;
    public Animator animator;

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
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
