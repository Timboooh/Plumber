using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerResetter : MonoBehaviour
{
    public bool IsSpawner = false;
    public bool IsResetter = false;

    public SpawnerCanon spawnerCanon = null;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnerCanon == null) Debug.LogError("No spawnercanon detected");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpawnLever")
        {
            spawnerCanon.SpawnRandom();
        } else if (other.name == "ClearLever")
        {
            spawnerCanon.Reset();
        }
    }
}
