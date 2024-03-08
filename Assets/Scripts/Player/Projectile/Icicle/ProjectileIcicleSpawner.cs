using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileIcicleSpawner : MonoBehaviour
{
    public GameObject icicleProjectilePrefab;

    public Transform spawnpoint;

    public float fireRate = 0.3f;
    private float tLeftToFire = 0f;

    void Update()
    {
        tLeftToFire -= Time.deltaTime;

        if (Input.GetMouseButton(1))
        {

            if (tLeftToFire <= 0)
            {
                Instantiate(icicleProjectilePrefab, spawnpoint.position, spawnpoint.rotation);
                tLeftToFire = fireRate;
            }
        }

    }
}
