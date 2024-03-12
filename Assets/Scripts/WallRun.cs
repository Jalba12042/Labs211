using UnityEngine;

public class WallRun : MonoBehaviour
{
    public float wallRunForce = 10f;
    public float wallRunDuration = 2f;

    private Rigidbody rb;
    private bool isWallRunning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isWallRunning)
        {
            // Implement wall jump or any other action when jumping off the wall
            // For simplicity, let's apply a force opposite to the wall normal
            rb.AddForce(-transform.forward * wallRunForce, ForceMode.Impulse);
            isWallRunning = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (IsWall(other))
        {
            // Start wall run
            isWallRunning = true;
            Invoke("StopWallRun", wallRunDuration);

            // Get the normal of the wall
            Vector3 wallNormal = other.transform.forward;

            // Align character's forward with the wall normal
            transform.forward = -wallNormal;

            // Apply force perpendicular to the wall
            Vector3 force = Vector3.Cross(Vector3.up, wallNormal) * wallRunForce;
            rb.AddForce(force, ForceMode.Force);
        }
    }

    void StopWallRun()
    {
        isWallRunning = false;
    }

    bool IsWall(Collider other)
    {
        return other.CompareTag("Wall");
    }
}
