using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSnowballSpawner : MonoBehaviour
{
    public GameObject snowballProjectilePrefab;

    public Transform spawnpoint;

    public float fireRate = 0.3f;
    private float tLeftToFire = 0f;

    void Update()
    {
        tLeftToFire -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {

            if (tLeftToFire <= 0)
            {
                Instantiate(snowballProjectilePrefab, spawnpoint.position, spawnpoint.rotation);
                tLeftToFire = fireRate;
            }
        }

    }
}
