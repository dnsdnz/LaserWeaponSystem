using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float maxLength;
    
    private Ray _rayMouse;
    private Vector3 _direction;
    private Quaternion _rotation;
    
    public UnityEvent onFire;
    
    #region Unity:Start
    private void Start()
    {
        GameManager.OnFire += OnFire;
    }

    #endregion

    #region Unity:OnDestroy
    private void OnDestroy()
    {
        GameManager.OnFire -= OnFire;
    }
    #endregion
    
    #region Event:OnFire
    private void OnFire()
    {
        Fire();

        onFire.Invoke();
    }
    

    #endregion

    #region Unity:Update
    private void FixedUpdate()
    {
        //movement codes from demo
        if (mainCamera != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            _rayMouse = mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(_rayMouse.origin, _rayMouse.direction, out hit, maxLength)) 
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = _rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
    }
    

    #endregion

    #region Mouse:Rotate
    private void RotateToMouseDirection (GameObject obj, Vector3 destination)
    {
        _direction = destination - obj.transform.position;
        _rotation = Quaternion.LookRotation(_direction);     
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, _rotation, 1);
    }
    #endregion

    #region Usage With Button-Removed
    //public Button fireButton;
    
    // private void OnEnable()
    // {
    //     fireButton.onClick.AddListener(Fire);
    // }
    //
    // private void OnDisable()
    // {
    //     fireButton.onClick.RemoveListener(Fire);
    // }
    #endregion

    #region Weapon:Fire
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
    #endregion
}