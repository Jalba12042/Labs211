using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        // Move the enemy forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Method to take damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle enemy death
    void Die()
    {
        // Perform any death-related actions (e.g., play death animation, spawn particles, etc.)
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
