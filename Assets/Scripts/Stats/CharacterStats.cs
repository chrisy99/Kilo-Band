using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public int damage = 1;
    public int health = 100;
    public float atkSpd = 1.0f;
    public float moveSpd = 1.0f;

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

    public void AddHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
        LevelLoader.Instance.LoadSpecificLevel("Game Over");
        //gameObject.SetActive(false);
    }
}
