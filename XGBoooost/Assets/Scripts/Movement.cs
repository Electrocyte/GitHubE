using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 200f;
    [SerializeField] float rotationThrust = 100;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip fuelSound;
    [SerializeField] ParticleSystem RsideThrusterParticles;
    [SerializeField] ParticleSystem LsideThrusterParticles;
    [SerializeField] ParticleSystem rocketJetParticles;
    AudioSource audioSource;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel") {
            Debug.Log("Boosting Fuel!");
            StartFuelSequence();
        }
        else if (other.tag == "FuelDump") {
            Debug.Log("Dumping Fuel!");
            StartFuelDump();
        }
        else if (other.tag == "NormalSpeed") {
            mainThrust = 200f;
        }
    }

    private void StartFuelDump()
    {
        StopCoroutine(PowerDown());  
        StartCoroutine(PowerDown());
    }

    IEnumerator PowerDown()
        {
            mainThrust *= 0.8f;
            yield return new WaitForSeconds(1f);
            mainThrust *= 1f;
        }

    private void StartFuelSequence()
    {
        audioSource.PlayOneShot(fuelSound);
        StopCoroutine(PowerUp());  
        StartCoroutine(PowerUp());
    }

    IEnumerator PowerUp()
        {
            mainThrust *= 1.5f;
            yield return new WaitForSeconds(3f);
            mainThrust *= 1f;
        }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space))
        {
            RocketUp();
        }
        else
        {
            RocketStop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LsideThrusterParticles.Play();
            ApplyRotation(-1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            RsideThrusterParticles.Play();
            ApplyRotation(1f);
        } else {
            RsideThrusterParticles.Stop();
            LsideThrusterParticles.Stop();
        }
    }

    private void RocketUp()
    {
        // Debug.Log("Thrusting!");
        // transform.Translate(0, mainThrust, 0); // too smooth
        rocketJetParticles.Play();
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust); // feels like a rocket
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void RocketStop()
    {
        audioSource.Stop();
        rocketJetParticles.Stop();
    }

    private void ApplyRotation(float direction)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime * direction);
        rb.freezeRotation = false;
    }
}
