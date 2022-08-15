using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody rb;
    [SerializeField] float timeToDrop = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
            meshRenderer = GetComponent<MeshRenderer>();
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            meshRenderer.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToDrop) {
            rb.useGravity = true;
            meshRenderer.enabled = true;
        }
    }
}
