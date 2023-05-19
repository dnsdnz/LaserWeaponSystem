using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] private Rigidbody rigidbody;
    
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(0, 0, speed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }
}