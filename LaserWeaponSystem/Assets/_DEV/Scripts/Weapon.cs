using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Button fireButton;

    private void OnEnable()
    {
        fireButton.onClick.AddListener(Fire);
    }

    private void OnDisable()
    {
        fireButton.onClick.RemoveListener(Fire);
    }

    private void Fire()
    {
        GameObject laser = LaserObjectPool.Instance.GetLaser();
        
        laser.transform.position = firePoint.position;
        laser.transform.rotation = firePoint.rotation;

        laser.SetActive(true);

        Laser laserScript = laser.GetComponent<Laser>();
        if (laserScript != null)
        {
            laserScript.SetSpeed(10f);
        }
    }
}