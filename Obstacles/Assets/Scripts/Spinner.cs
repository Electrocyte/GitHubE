using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xval = 1f; 
    [SerializeField] float yval = 1f; 
    [SerializeField] float zval = 1f; 
    // [SerializeField] float moveSpeed = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xval,yval,zval);
    }
}
