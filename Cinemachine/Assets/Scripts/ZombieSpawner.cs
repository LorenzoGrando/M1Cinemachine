using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private TriggerArea targetTriggerArea;
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private Transform lowerLeftBounds, upperRightBounds;
    [SerializeField]
    private Vector2Int minMaxZombieAmount;

    void OnEnable()
    {
        targetTriggerArea.OnEnterTrigger += CallSpawnZombie;
    }

    void OnDisable()
    {
        targetTriggerArea.OnEnterTrigger -= CallSpawnZombie;
    }

    public void CallSpawnZombie() {
        int amountToSpawn = UnityEngine.Random.Range(minMaxZombieAmount.x, minMaxZombieAmount.y + 1);

        for(int i = 0; i < amountToSpawn; i++) {
            SpawnZombie(GeneratePositionInBounds());
        }
    }

    private Vector3 GeneratePositionInBounds() {
        Vector3 newPos = new();

        newPos.x = UnityEngine.Random.Range(lowerLeftBounds.position.x, upperRightBounds.position.x);
        newPos.y = transform.position.y;
        newPos.z = UnityEngine.Random.Range(lowerLeftBounds.position.z, upperRightBounds.position.z);

        return newPos;
    }

    private void SpawnZombie(Vector3 position) {
        Debug.Log("Spawned Zombie");
        Instantiate(zombiePrefab, position, Quaternion.identity);
    }
}
