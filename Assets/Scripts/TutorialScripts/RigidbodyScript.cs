using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyScript : MonoBehaviour {
    
    public float moveSpeed = 5f;

    private Rigidbody _rigidbody;

    void Start() {

        // Get the Rigidbody component
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {

        // Get the input from the tank movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the rigidbody
        MoveByVelocity(horizontal, vertical);
        // MoveByForce(horizontal, vertical);

    }

    void MoveByVelocity(float horizontal, float vertical) {

        // Calculate the velocity
        Vector3 velocity = new Vector3(horizontal, 0, vertical) * moveSpeed;
        
        // Keep the y velocity
        velocity.y = _rigidbody.velocity.y;

        // Set the velocity
        _rigidbody.velocity = velocity;
    }

    void MoveByForce(float horizontal, float vertical) {

        // Calculate the force
        Vector3 force = new Vector3(horizontal, 0, vertical) * moveSpeed;

        // Add the force
        _rigidbody.AddForce(force);
    }

}
