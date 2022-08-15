using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayperiod = 1f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Debug.Log("Melons, I passed the post!");
            finishEffect.Play();
            Invoke("ReloadScene", delayperiod);
            GetComponent<AudioSource>().Play();
        }
    }
    void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    
}
