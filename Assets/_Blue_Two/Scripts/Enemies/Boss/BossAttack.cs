using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject projectile;
    public GameObject zombie;
    public float fireRate = 5f;

    private float nextFire;
    private BossHealth bosshealth;
    private bool spawned1 = false;
    private bool spawned2 = false;
    private float max_health;
    void Start()
    {
        nextFire = Time.time;
        bosshealth = GetComponent<BossHealth>();
        max_health = bosshealth.health;
        //SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        if (!spawned1 && bosshealth.health < max_health * 0.5)
        {
            spawned1 = true;
            SpawnZombie();
        }

        if (!spawned2 && max_health * 0.25 > bosshealth.health)
        {
            spawned2 = true;
            SpawnZombie();
            Invoke("SpawnZombie", 2f);
        }


    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, transform.rotation); 
            nextFire = Time.time + fireRate;
        }
    }

    void SpawnZombie()
    {

        Vector3 spawnPosition1 = transform.position + Vector3.left * 3 + Vector3.up * 1;
        Vector3 spawnPosition2 = transform.position + Vector3.right * 3 + Vector3.up * 1;
        Instantiate(zombie, spawnPosition1, transform.rotation);
        Instantiate(zombie, spawnPosition2, transform.rotation);

    }

}
