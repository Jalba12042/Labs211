using UnityEngine;

public class BaseSpaceship : MonoBehaviour
{
    public float movementSpeed = 5f;
    public int health = 100;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    protected virtual void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
