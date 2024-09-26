using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CollisionScript : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Wall")) {
            Debug.Log("Hit the wall");
        }
    }
    
}
