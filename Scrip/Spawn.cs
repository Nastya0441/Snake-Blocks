using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Food;
    public List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnBalls();
    }

    void SpawnBalls()
    {
        for (int i = 0; i < Food.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(Food[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }
}
