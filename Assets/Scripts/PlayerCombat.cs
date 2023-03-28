using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public event System.Action<int, int> onHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (onHealthChanged != null)
        {
            onHealthChanged(currentHealth, maxHealth);
        }
    }

    public void Die()
    {
        Debug.Log("You have died!");
    }
}
