using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyOld : MonoBehaviour
{
    public EnemyType enemyType;
    public CharacterStats stats;
    public Rigidbody rigidBody;
    public Transform target;
    public EnemyController ec;
    private float lastAttackedAt = 0.0f;

    public float interactionRadius = 3f;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        rigidBody = GetComponent<Rigidbody>();
        target = PlayerManager.instance.player.transform;
        ec = GetComponent<EnemyController>();

        switch (enemyType)
        {
            case EnemyType.Normal:
                stats.damage = 10;
                stats.moveSpd = 9.0f;
                stats.atkSpd = 1.0f;
                ec.baseRadius = 3.0f;
                ec.agent.speed = stats.moveSpd;
                break;

            case EnemyType.Slow:
                stats.damage = 20;
                stats.moveSpd = 7.0f;
                stats.atkSpd = 3.0f;
                ec.baseRadius = 9.0f;
                ec.agent.speed = stats.moveSpd;
                break;

            case EnemyType.Fast:
                stats.damage = 4;
                stats.moveSpd = 12.5f;
                stats.atkSpd = 0.3f;
                ec.baseRadius = 1.0f;
                ec.agent.speed = stats.moveSpd;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < interactionRadius)
        {
            if (Time.time > lastAttackedAt + stats.atkSpd)
            {
                PlayerManager.instance.player.GetComponent<CharacterStats>().TakeDamage(stats.damage);
                Debug.Log("Player within range, attacking...");
                lastAttackedAt = Time.time;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("Collision with player detected");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            rigidBody.constraints = RigidbodyConstraints.None;
            Debug.Log("Collision exit with player detected");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);

    }
}