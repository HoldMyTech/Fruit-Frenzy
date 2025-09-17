using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits; // Drag your fruit prefabs here in the Inspector
    public float spawnInterval = 1.5f; // time between spawns
    public float xRange = 8f; // how wide the fruits can spawn
    public float ySpawn = 6f; // how high in the sky they spawn

    private void Start()
    {
        InvokeRepeating("SpawnFruit", 1f, spawnInterval);
    }

    void SpawnFruit()
    {
        int index = Random.Range(0, fruits.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), ySpawn, 0f);
        Instantiate(fruits[index], spawnPos, Quaternion.identity);
    }
}
