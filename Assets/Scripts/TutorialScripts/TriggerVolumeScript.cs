using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeScript : MonoBehaviour {
    
    void OnTriggerEnter(Collider other) {
        Debug.Log("Entered trigger volume");
    }
}
