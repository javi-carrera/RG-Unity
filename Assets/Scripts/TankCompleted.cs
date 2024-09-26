using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCompleted : MonoBehaviour {

    [Header("Tank Movement Settings")]
    public float maxLinearVelocity;
    public float maxAngularVelocity;
    public float linearTimeConstant;
    public float angularTimeConstant;

    private Rigidbody _rigidbody;
    private Vector3 _targetLinearVelocity;
    private Vector3 _targetAngularVelocity;
    private Vector3 _currentLinearVelocity;
    private Vector3 _currentAngularVelocity;


    [Header("Turret Settings")]
    public Transform turret;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float turretRotationSpeed;
    public float shootVelocity;
    public float fireRate;

    private float _turretAngle;
    private float _cooldown;
    private bool _fire;



    private void Start() {

        _rigidbody = GetComponent<Rigidbody>();

        _currentLinearVelocity = _rigidbody.velocity;
        _currentAngularVelocity = _rigidbody.angularVelocity;

        _turretAngle = 0.0f;
        _cooldown = 1.0f / fireRate;
        
    }

    private void Update() {
        
        MoveTank();
        MoveTurret();

        _fire = Input.GetButton("Fire1");
        _cooldown -= Time.deltaTime;

        if (_fire && _cooldown <= 0)
            Shoot();

    }

    private void MoveTank() {

        // Get the input from the tank movement
        _targetLinearVelocity = maxLinearVelocity * new Vector3(0, 0, Input.GetAxis("Vertical"));
        _targetAngularVelocity = maxAngularVelocity * new Vector3(0, Input.GetAxis("Horizontal"), 0);

        // Lerp the target velocities
        _currentLinearVelocity = Vector3.Lerp(_currentLinearVelocity, _targetLinearVelocity, linearTimeConstant * Time.deltaTime);
        _currentAngularVelocity = Vector3.Lerp(_currentAngularVelocity, _targetAngularVelocity, angularTimeConstant * Time.deltaTime);

        // Apply the target velocities to the tank's rigidbody
        _rigidbody.velocity = transform.TransformDirection(_currentLinearVelocity);
        _rigidbody.angularVelocity = transform.TransformDirection(_currentAngularVelocity);
    }

    private void MoveTurret() {
        
        // Get the input from the mouse scroll wheel
        _turretAngle += Input.GetAxis("Mouse ScrollWheel") * turretRotationSpeed;

        // Apply the rotation to the turret
        turret.transform.localEulerAngles = new Vector3(0, _turretAngle, 0);

    }


    private void Shoot() {

        // Reset the cooldown
        _cooldown = 1.0f / fireRate;
        
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab);
        
        // Get the rigidbody of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        // Set the position and rotation of the bullet
        bullet.transform.SetPositionAndRotation(shootingPoint.position, shootingPoint.rotation);

        // Set the velocity of the bullet
        rb.AddForce(shootVelocity * shootingPoint.forward, ForceMode.VelocityChange);

    }
}
