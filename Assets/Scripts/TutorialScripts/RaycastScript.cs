using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour{

    public float rayLength = 10f;
    public LayerMask layerMask;

    void Update() {

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, layerMask)) {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            Debug.Log("Raycast hit " + hit.collider.gameObject.name);
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.green);
        }
    }
}
