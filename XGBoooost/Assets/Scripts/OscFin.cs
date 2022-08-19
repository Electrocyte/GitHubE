using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscFin : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = new Vector3(15, 0, 0);

        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // 6.283...

        float rawSineWave = Mathf.Sin(tau * cycles); // -1 to 1

        movementFactor = (rawSineWave + 1f) / 2; // convert scale 0 to 1
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
        
    }

}

        
// var finishLine = GameObject.FindGameObjectsWithTag("Finish");
// Debug.Log(finishLine);

// if (finishLine != null) {
//     movementVector = new Vector3(10, 0, 0); 
// }