using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSysem;

public class PlayerControls : MonoBehaviour
{
    [Header("General setup settings.")]
    [Tooltip("How fast ship moves up and down based upon player input.")] 
    [SerializeField] float controlSpeed = 40f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 12f;
    [SerializeField] float zRange = 8f;
    [Header("Laser gun array.")]
    [Tooltip("Pew Pew.")]     
    [SerializeField] GameObject[] lasers;
    [SerializeField] GameObject[] particleLance;
    [Header("Position and rotation for spacecraft.")]
    [Tooltip("Pitch = x; yaw = y; roll = z.")] 
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

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
            SetLasersActive(true);
        } else if (Input.GetButton("Fire2")) {
            SetParticleLanceActive(true);
        } else {
            SetLasersActive(false);
            SetParticleLanceActive(false);
        }
    }

    private void SetParticleLanceActive(bool activateLance)
    {
        foreach (GameObject lance in particleLance) {
            var emissionModule = lance.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = activateLance;
        }
    }

    private void SetLasersActive(bool activateLasers)
    {
        foreach (GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = activateLasers;
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