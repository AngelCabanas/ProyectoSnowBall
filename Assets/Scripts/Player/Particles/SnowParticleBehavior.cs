using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticleBehavior : MonoBehaviour
{
    public float xForce = 1.0f;
    public float yForce = 1.0f;
    private Quaternion rotation = Quaternion.identity;

    private Rigidbody rb = null;

    public float destroyTime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rotation.x = Random.Range(0,30);
        rotation.y = Random.Range(0, 179);
        transform.rotation = rotation;

        rb.AddForce(transform.forward * xForce * Random.Range(500, 1000));
        rb.AddForce(transform.up * yForce * Random.Range(500, 1000));
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
