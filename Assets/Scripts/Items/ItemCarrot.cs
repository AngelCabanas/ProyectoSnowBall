using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCarrot : MonoBehaviour
{
    public int hpHeal = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth jugador = other.GetComponent<PlayerHealth>();

            if (jugador != null && jugador.health < jugador.maxHealth)
            {
                jugador.Heal(hpHeal);
                Destroy(gameObject);
            }
        }
    }
}
