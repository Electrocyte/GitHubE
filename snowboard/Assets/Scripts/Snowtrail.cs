using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowtrail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem snowParticles;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground"){
            snowParticles.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground"){
            snowParticles.Stop();
        }        
    }
}
