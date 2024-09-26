using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    [Header("Tank Movement Settings")]

    // [TODO]


    [Header("Turret Settings")]

    // [TODO]

    public float fireRate;
    private float _cooldown;




    private void Start() {

        // [TODO]

        _cooldown = 1.0f / fireRate;
        
    }

    private void Update() {

        // Decrease the cooldown
        _cooldown -= Time.deltaTime;


    }

    private void MoveTank() {

        // [TODO]
        
    }

    private void MoveTurret() {
        
        // [TODO]

    }


    private void Shoot() {

        // [TODO]

    }
}
