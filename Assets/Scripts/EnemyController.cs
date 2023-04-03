using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float targetRadius = 3f;
    public Transform target;
    NavMeshAgent agent;
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
        agent.speed = enemyStats.moveSpd;
    }

    // Update is called once per frame
    protected void Update()
    {
        targetRadius = target.GetComponent<playerController>().interaction_radius;
        float distance = Vector3.Distance(target.position, transform.position);
        lookRadius = 3f + targetRadius;
        if (distance <= lookRadius)
        {
            StartCoroutine(monsterRoarAnim());

            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                
                return;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    IEnumerator monsterRoarAnim()
    {  
            anim.SetBool("playerHeard", true);
            monsterRoar.enabled= true;

        yield return new WaitForSeconds(120F);
    }
}