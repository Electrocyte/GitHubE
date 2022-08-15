using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();   

    }

    void MovePlayer() {
        float x_input = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float z_input = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(x_input, 0, z_input);
    }

    void PrintInstructions() {
        Debug.Log("Welcome to the game.");
        Debug.Log("Move with WASD or arrow keys.");
        Debug.Log("Don't hit the walls");
    }
}
