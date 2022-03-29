using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCanon : MonoBehaviour
{
    public Grid parentGrid = null;
    public GameObject[] Prefabs = null;
    public Vector3 SpawningOffset = new Vector3(0, 0.6f, 0);
    public Vector3 SpawningForce = new Vector3 (5, 5, 0);
    public List<string> IgnoreNames = new List<string>() { "InputPipe", "OutputPipe" };

    public void SpawnRandom(Grid grid = null)
    {
        if (grid == null) grid = parentGrid;

        GameObject gameObjectToSpawn = Prefabs[Random.Range(0, Prefabs.Length)];
        
        GameObject spawnedGameObject = Instantiate(gameObjectToSpawn, parentGrid.transform);
        spawnedGameObject.transform.position = gameObject.transform.position + SpawningOffset;
        spawnedGameObject.GetComponent<Rigidbody>().AddForce(SpawningForce, ForceMode.Impulse);
    }

    public void Reset(Grid grid = null)
    {
        if (grid == null) grid = parentGrid;

        foreach(Transform child in grid.transform)
        {
            if (!IgnoreNames.Contains(child.name)) Destroy(child.gameObject);
        }

    }
}
