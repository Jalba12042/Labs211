using UnityEngine;
using UnityEngine.AI;

public class EnemyShip : BaseSpaceship
{
    public float detectionRange = 10f;
    public float damageRange = 1.5f;
    public float wanderRadius = 5f;
    public float wanderTimer = 5f;

    private Transform player;
    private Vector3 randomDestination;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GetNewRandomDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            FollowPlayer();
        }
        else
        {
            Wander();
        }

        if (Vector3.Distance(transform.position, player.position) <= damageRange)
        {
            DamagePlayer();
        }
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            GetNewRandomDestination();
            timer = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, randomDestination, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, randomDestination) < 0.1f)
        {
            GetNewRandomDestination();
        }
    }

    void GetNewRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        randomDestination = hit.position;
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
    }

    void DamagePlayer()
    {
        player.GetComponent<BaseSpaceship>().health -= 10;
    }
}
