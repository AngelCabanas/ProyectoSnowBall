using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;

    MeshRenderer[] meshRenderers;

    public Material base_material;
    public Material damage_material;

    public float timeToDamageBlink = 0.2f;
    private float timeLeftToDamageBlink;
    private bool isBlinking = false;

    private UIPlayerHealth hPComponent;

    void Start()
    {
        health = maxHealth;
        timeLeftToDamageBlink = timeToDamageBlink;

        hPComponent = GetComponent<UIPlayerHealth>();
        hPComponent.SetUIHealth(health);

        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (isBlinking)
        {
            timeLeftToDamageBlink -= Time.deltaTime;
        }

        if (timeLeftToDamageBlink <= 0)
        {
            foreach (var renderer in meshRenderers)
            {
                renderer.material = base_material;
            }

            isBlinking = false;
            timeLeftToDamageBlink = timeToDamageBlink;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        hPComponent.SetUIHealth(health);

        if (health <= 0)
        {
            Die();
        }
        else
        {
            DamageBlink();
        }
    }

    public void Heal(int healHealth)
    {
        health += healHealth;
        hPComponent.SetUIHealth(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void DamageBlink()
    {
        isBlinking = true;

        foreach (var renderer in meshRenderers)
        {
            renderer.material = damage_material;
        }
    }

    public void Die()
    {
        Transform childObject = transform.Find("Player");
        Destroy(childObject.gameObject);

        gameObject.transform.DetachChildren();

        Destroy(gameObject);
    }
}
