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
            playerHeard= true;
            monsterRoarAnim();
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                anim.SetTrigger("Attack");
                return;
            }
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

    void monsterRoarAnim()
    {
        if (playerHeard == true && Vector3.Distance(target.position, transform.position) <= agent.stoppingDistance)
        {
            anim.SetTrigger("attack");
            playerHeard = false;
            monsterRoar.Play();

        }
        else if(playerHeard == true) 
        {
            anim.SetTrigger("playerHeard");
            playerHeard = false;
            monsterRoar.Play();
        }

        else
        {
            anim.ResetTrigger("playerHeard");
            anim.ResetTrigger("Attack");
            playerHeard = false;
        }
    }
}