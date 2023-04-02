using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public int damage;
    public int armor;
    public float AtkSpd;

    public event System.Action<int, int> onHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        // Debug.Log(transform.name + " takes " + damage + " damage.");
        // Debug.Log(transform.name + " has " + currentHealth  + " hp remaining.");

        if (currentHealth <= 0)
        {
            Die();
        }

        if (onHealthChanged != null)
        {
            onHealthChanged(currentHealth, maxHealth);
        }
    }

    public void AddHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");

        gameObject.SetActive(false);// placeholder
        /*
         *  maybe just move it out of view
         * drop loot
         * re
         */
    }
}
