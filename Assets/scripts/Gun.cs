using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Text bulletCounter;
    public Text totalBullets;
    public GameObject bananaPistol;
    public bool isFiring = false;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public GameObject impactEffect;
    public Animator animator;

    private float nextTimeToFire = 0f;
    public int maxAmmo = 9;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);       //zet de reloading animatie uit
    }

    void Update()
    {
        bulletCounter.text = currentAmmo.ToString();
        totalBullets.text = maxAmmo.ToString();
        if(isReloading)
        {
            return;
        }

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))  //activeert reload bij 0 kogels of bij het drukken op R
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
            Shoot();
        }
    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        bananaPistol.GetComponent<Animator>().Play("fireGun");      //speelt de "fireGun" animatie af
        yield return new WaitForSeconds(0.5f / fireRate);           
        bananaPistol.GetComponent<Animator>().Play("idleGun");      //speelt de "idleGun" animatie af
        isFiring = false;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot ()
    {
        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))    //checkt of de raycast een hit heeft
        {
            Debug.Log(hit.transform.name);                                                          //zet de naam van het geraakte object in de console
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();                                 
            if(target != null)                                                                      //controleert of de EnemyAI bestaat(meer dan 0 health heeft)
            {
                target.TakeDamage(damage);                                                          //doet damage aan de EnemyAI die geraakt is
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
