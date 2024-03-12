using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerShipPrefabs; // Array of player ship prefabs representing different ship types
    public Transform playerSpawnPoint;
    public int initialEnemyCount = 5;

    private int currentShipIndex = 0; // Index of the currently selected player ship

    void Start()
    {
        // Spawn initial player ship
        SpawnPlayerShip();
    }

    void SpawnPlayerShip()
    {
        // Instantiate the selected player ship prefab at the player spawn point
        Instantiate(playerShipPrefabs[currentShipIndex], playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    // Method to swap the player ship
    public void SwapPlayerShip()
    {
        // Destroy the current player ship
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        // Update the current ship index
        currentShipIndex = (currentShipIndex + 1) % playerShipPrefabs.Length;

        // Spawn the new player ship
        SpawnPlayerShip();
    }
}
