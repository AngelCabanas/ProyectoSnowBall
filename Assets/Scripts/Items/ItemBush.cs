using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBush : MonoBehaviour
{
    public GameObject carrotPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(carrotPrefab, transform.position, Quaternion.identity);
        }
    }
}
