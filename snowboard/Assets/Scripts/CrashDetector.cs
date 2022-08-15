using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayperiod = 0.5f;
    [SerializeField] ParticleSystem bloodEffect;
    [SerializeField] ParticleSystem whiteoutEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Ground")
        // if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Fuck, I smashed my head!");
            bloodEffect.Play();
            whiteoutEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayperiod);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
