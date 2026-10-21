using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupPrefab = null;
    [SerializeField]
    private Transform minSpawnArea = null;
    [SerializeField]
    private Transform maxSpawnArea = null;
    [SerializeField]
    private float minSpawnRate = 1.0f;
    [SerializeField]
    private float maxSpawnRate = 10.0f;

    private float nextSpawnTime = 0.0f;
    private void Awake()
    {
        nextSpawnTime = 5.0f;
    }
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime < 0.0f)
        {
            SpawnPickup();
            nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    private void SpawnPickup()
    {
        Vector3 SpawnPosition = Vector3.zero;
        SpawnPosition.x = Random.Range(minSpawnArea.position.x, maxSpawnArea.position.x);
        SpawnPosition.y = Random.Range(minSpawnArea.position.y, maxSpawnArea.position.y);
        SpawnPosition.z = minSpawnArea.position.z;
        Instantiate(pickupPrefab, SpawnPosition, Quaternion.identity);
    }
}
