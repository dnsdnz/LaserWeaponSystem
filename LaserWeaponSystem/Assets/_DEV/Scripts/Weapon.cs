using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    
    public UnityEvent onFire;

    private void OnEnable()
    {
        onFire.AddListener(Fire);
    }

    private void OnDisable()
    {
        onFire.RemoveListener(Fire);
    }
    
    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}