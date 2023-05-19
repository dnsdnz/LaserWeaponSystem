using System.Collections.Generic;
using UnityEngine;

public class LaserObjectPool : MonoBehaviour
{
    public static LaserObjectPool Instance { get; private set; }

    public GameObject laserPrefab;
    public int initialPoolSize = 10;

    private List<GameObject> _pooledLasers = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateLaser();
        }
    }

    private GameObject CreateLaser()
    {
        GameObject laser = Instantiate(laserPrefab);
        laser.SetActive(false);
        _pooledLasers.Add(laser);
        return laser;
    }

    public GameObject GetLaser()
    {
        foreach (GameObject laser in _pooledLasers)
        {
            if (!laser.activeInHierarchy)
            {
                return laser;
            }
        }

        GameObject newLaser = CreateLaser(); //no active
        return newLaser;
    }
}