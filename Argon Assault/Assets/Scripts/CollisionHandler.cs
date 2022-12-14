using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosionVFX;
    // public AudioClip tokenGrabClip;
    // AudioSource explosionSFX;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        Debug.Log("Crashed");
    }

    // private void PlayKaboom()
    // {
    //     explosionSFX.PlayOneShot(tokenGrabClip);
    // }

    void StartCrashSequence()
    {
        explosionVFX.Play();
        // PlayKaboom();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
