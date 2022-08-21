using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSysem;

public class PlayerControls : MonoBehaviour
{
    
    // [SerializeField] InputAction movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // void OnEnable() {
    //     movement.Enable();
    // }

    // void OnDisable() {
        // movement.Disable();
    // }

    // Update is called once per frame
    void Update()
    {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;

        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");
    }
}
