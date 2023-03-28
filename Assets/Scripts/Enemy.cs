using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator _animator;
    private float attackCooldown = 2f;
    
    private int myDamage = 10;
    private float atkSpeed = 1.0f;

    public string enemyType;

    public void Attack(PlayerCombat player, int damageTaken)
    {
        PlayerCombat combat = playerManager.player.GetComponent<PlayerCombat>();
        if (attackCooldown <= 0f)
        {
            if (combat != null)
            {
                combat.TakeDamage(myDamage);
                Debug.Log("Attacked " + this.name + " for " + myDamage + ".");
            }

            attackCooldown = 2f;

            //TODO: Set animation
            //_animator.SetTrigger("Attack")

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
}
