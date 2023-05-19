using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void FireAction();
    
    public static event FireAction OnFire;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        OnFire?.Invoke();
    }
}