using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObjectPool : MonoBehaviour
{
    [SerializeField] private Lazer laserPrefab;
    [SerializeField] private int poolSize;

    private List<Lazer> _laserPool;
}