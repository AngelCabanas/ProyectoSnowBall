using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnowParticleSpawner))]

public class SnowParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab = null;
    public int numberOfParticles = 5;

    public void CreateExplosion()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
        }
    }
}
