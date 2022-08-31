using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            if (isPlaceable) {
                Debug.Log(transform.name);
            }
        }
    }
}
