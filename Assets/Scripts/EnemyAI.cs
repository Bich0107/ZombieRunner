using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float attackRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        else isProvoked = false;
    }

    void EngageTarget()
    {
        if (distanceToTarget >= attackRange)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= attackRange)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        navMeshAgent.destination = target.transform.position;
    }

    void AttackTarget()
    {
        Debug.Log($"Enemy {name} have attack {target.name}");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
