using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnowParticleSpawner))]

public class ProjectileIcicleBehavior : MonoBehaviour
{

    public float force = 1f;
    public float destroyTime = 3f;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        print("snowball projectile impacted !");

        SnowParticleSpawner snowParticleSpawnerComp = GetComponent<SnowParticleSpawner>();
        snowParticleSpawnerComp.CreateExplosion();

        Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force * 2000);
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            SnowParticleSpawner snowParticleSpawnerComp = GetComponent<SnowParticleSpawner>();
            snowParticleSpawnerComp.CreateExplosion();

            Destroy(gameObject);
        }
    }
}
