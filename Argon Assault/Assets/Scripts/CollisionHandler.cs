using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + "--colided with__" + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log($"{this.name} --colided with__ {other.gameObject.name}");
    }
}
