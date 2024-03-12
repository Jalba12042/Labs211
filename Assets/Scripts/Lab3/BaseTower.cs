using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;

    protected float fireCountdown = 0f;
    protected Transform target;

    protected virtual void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    protected virtual void FindTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    protected virtual void Shoot()
    {
        // Implement shooting logic for the base tower
        Debug.Log("BaseTower: Pew pew!"); // Placeholder message
    }
}

public class BasicTower : BaseTower
{
    protected override void FindTarget()
    {
        base.FindTarget(); // Use base class logic to find target
    }

    protected override void Shoot()
    {
        base.Shoot(); // Use base class shooting logic
        // Custom shooting logic for BasicTower if needed
    }
}

public class SniperTower : BaseTower
{
    public float sniperRangeMultiplier = 2f;

    protected override void FindTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range * sniperRangeMultiplier)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range * sniperRangeMultiplier)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    protected override void Shoot()
    {
        Debug.Log("SniperTower: Taking the shot!");
    }
}


public class SplashTower : BaseTower
{
    protected override void FindTarget()
    {
        base.FindTarget(); // Use base class logic to find target
    }

    protected override void Shoot()
    {
        base.Shoot(); // Use base class shooting logic
        // Custom shooting logic for SplashTower if needed
    }
}

