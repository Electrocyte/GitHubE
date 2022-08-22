using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSysem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 40f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 12f;
    [SerializeField] float zRange = 8f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] lasers;
    float yThrow;
    float xThrow;
    float zThrow;

    void Awake() {
        transform.localPosition = new Vector3(0f, 0f, 0f);  
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);  
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1")) {
            ActivateLasers();
        } else {
            DeActivateLasers();
        }
    }

    private void DeActivateLasers()
    {
        foreach (GameObject laser in lasers) {
            laser.SetActive(false);
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject laser in lasers) {
            laser.SetActive(true);
        }
    }

    void ProcessRotation() {
        float pitchFromPos = transform.localPosition.y * positionPitchFactor;
        float pitchFromCtrl = yThrow * controlPitchFactor;

        float pitch = pitchFromPos + pitchFromCtrl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);  
    }

    void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        zThrow = Input.GetAxis("Z");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float zOffset = zThrow * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;
        float newZPos = transform.localPosition.z + zOffset;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);
        float clampedZPos = Mathf.Clamp(newZPos, -zRange, zRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, clampedZPos);
    }
}


    // [SerializeField] InputAction movement;

    // void OnEnable() {
    //     movement.Enable();
    // }

    // void OnDisable() {
        // movement.Disable();
    // }

    // Update is called once per frame
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;