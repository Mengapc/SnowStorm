using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float spawnDistance = 2.0f; // Distance in front of the player to spawn the cube
    public float cubeSize = 1.0f; // Size of the cube

    void Update()
    {
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        // Calculate the spawn position in front of the player
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // Create a new cube GameObject
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Set the position and scale of the cube
        cube.transform.position = spawnPosition;
        cube.transform.localScale = Vector3.one * cubeSize;

        // Add a Rigidbody component for physics
        cube.AddComponent<Rigidbody>();
    }
}
