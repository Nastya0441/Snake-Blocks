using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    
    public MeshCollider _plane;
    public GameObject[] Food;

    Vector3 SpawnPos;

    Vector3 sizeCol = new Vector3(0f, 0f, 1f);
    Vector3 center = new Vector3(0, .5f, 0);
    float x, z, y;

    public Collider[] colliders;

    bool check;

    private void Start()
    {
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
        StartPos();
    }

    void StartPos()
    {
        x = Random.Range(_plane.transform.position.x - Random.Range(_plane.bounds.extents.x, _plane.bounds.extents.x), _plane.transform.position.x + Random.Range(0, _plane.bounds.extents.x));
        z = Random.Range(_plane.transform.position.z - Random.Range(_plane.bounds.extents.z, _plane.bounds.extents.z), _plane.transform.position.z + Random.Range(0, _plane.bounds.extents.z));
        y = Random.Range(_plane.transform.position.y - Random.Range(_plane.bounds.extents.y, _plane.bounds.extents.y), _plane.transform.position.y + Random.Range(0, _plane.bounds.extents.y));
        SpawnPos = new Vector3(x, y, z);   //y - 1.15f
        check = CheckSpawnPoint(SpawnPos);
        if (check)
        {
            Instantiate(Food[Random.Range(0, Food.Length)], new Vector3(x, y, z), transform.rotation);  
            
        }
    }

    bool CheckSpawnPoint(Vector3 spawnpos)
    {
        colliders = Physics.OverlapBox(spawnpos, sizeCol);
        if (colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}

