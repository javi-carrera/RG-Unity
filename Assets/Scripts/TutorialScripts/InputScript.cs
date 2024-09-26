using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;

    void Update() {

        // Move the cube
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);


        // Rotate the cube
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }


        // Change the speed with the mouse wheel
        moveSpeed += Input.GetAxis("Mouse ScrollWheel") * 5f;

    }
}
