using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

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

    private float lastDistractedAt = 0.0f;
    public bool distracted;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetRadius = target.GetComponent<playerController>().interaction_radius;
        enemyStats = GetComponent<Enemy>().GetComponent<CharacterStats>();
        EventManager.instance.onObjectThrown += OnObjectThrown;
    }

    // Update is called once per frame
    protected void Update()
    {
        targetRadius = target.GetComponent<playerController>().interaction_radius;
        float distance = Vector3.Distance(target.position, transform.position);
        lookRadius = baseRadius + targetRadius;

        if (!distracted)
        {
            if (distance <= lookRadius)
            {
                //playerHeard= true;
                //monsterRoarAnim();
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget(target);
                    anim.SetTrigger("Attack");
                    return;
                }
            }
        }
        else if (Time.time > lastDistractedAt + 5.0f)
        {
            Debug.Log(Time.time);
            distracted = false;
        }
    }

    void FaceTarget(Transform target)
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

    public void OnObjectThrown(items heldObject)
    {
        Debug.Log("Thrown Object Detected");
        distracted = true;
        Transform thrownObject = heldObject.gameObject.transform;
        Debug.Log(thrownObject.position);

        float objectDistance = Vector3.Distance(thrownObject.position, transform.position);
        float playerDistance = Vector3.Distance(target.position, transform.position);
        Debug.Log("Distance: " + objectDistance);
        float objectLookRadius = baseRadius + 20.0f;
        Debug.Log("LookRadius: " + lookRadius);

        if (playerDistance < lookRadius)
        {
            return;
        }

        if (objectDistance <= objectLookRadius)
        {
            agent.SetDestination(thrownObject.position);
            Debug.Log("Destination Set to: " + thrownObject.position);
            lastDistractedAt = Time.time;
        }

    }
}

/*
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
*/
