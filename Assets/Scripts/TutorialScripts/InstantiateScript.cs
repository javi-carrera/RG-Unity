using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour {
    public GameObject original;
    public float range = 10f;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            Vector3 randomPosition = new Vector3(
                Random.Range(-range, range),
                Random.Range(-range, range),
                Random.Range(-range, range)
            );

            // GameObject copy = Instantiate(original, randomPosition, Quaternion.identity);
            GameObject copy = Instantiate(original, Vector3.zero, Quaternion.identity);
            Destroy(copy, 5f);

        }
    }
}
