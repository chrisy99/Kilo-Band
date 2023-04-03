using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float baseRadius = 3f;
    public float targetRadius = 3f;
    public Transform target;
    public NavMeshAgent agent;
    public AudioSource footstepSound, monsterRoar;
    public Animator anim;
    public CharacterStats enemyStats;
    public bool playerHeard;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetRadius = target.GetComponent<playerController>().interaction_radius;
        enemyStats = GetComponent<Enemy>().GetComponent<CharacterStats>();

    }


    // Update is called once per frame
    protected void Update()
    {
        
        targetRadius = target.GetComponent<playerController>().interaction_radius;
        float distance = Vector3.Distance(target.position, transform.position);
        lookRadius = baseRadius + targetRadius;

        if (distance <= lookRadius)
        {
            anim.SetFloat("Movement", 1, 0.3f, Time.deltaTime);
            StartCoroutine(monsterRoarTask());
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                anim.SetTrigger("Attack");
                return;
            }
        }
        else if (agent.speed < 1)
        {
            anim.SetFloat("Movement", 0, 0.3f, Time.deltaTime);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    IEnumerator monsterRoarTask()
    {
        monsterRoar.Play();
        yield return null;
    }
}
