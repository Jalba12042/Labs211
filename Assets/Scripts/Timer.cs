using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private bool isRunning = true; // Flag to control whether the timer is running or not

    void Start()
    {
        timer = 0f; // Start the timer at 0 seconds
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime; // Increment the timer if it's running
            UpdateTimerDisplay();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger")) // Check if the collider is the trigger
        {
            isRunning = false; // Stop the timer when the trigger is reached
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f); // Calculate minutes
        int seconds = Mathf.FloorToInt(timer % 60f); // Calculate seconds

        // Update the TextMeshProUGUI component with the formatted time string
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
