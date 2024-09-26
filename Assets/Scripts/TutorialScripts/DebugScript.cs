using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

    // public string myString;

    void Start() {
        Debug.Log("This is a debug message");
    }

    void Update() {
        // Debug.LogWarning($"This is a warning message with myString: {myString}");

        Debug.LogWarning($"This is a warning message at time {Time.time}");
    }

    void OnDisable() {
        Debug.LogError("This is an error message");
    }
}
