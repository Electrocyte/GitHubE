using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 5f;
    int xMove;
    System.Random r;
    
    // Start is called before the first frame update
    void Start()
    {
        r = new System.Random();
        xMove = r.Next(0, 10);
        Debug.Log(xMove);
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = new Vector3(xMove, 28, 0);

        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // 6.283...

        float rawSineWave = Mathf.Sin(tau * cycles); // -1 to 1

        movementFactor = (rawSineWave + 1f) / 2; // convert scale 0 to 1
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
        
    }

}
