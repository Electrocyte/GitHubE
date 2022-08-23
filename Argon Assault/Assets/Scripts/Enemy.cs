using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
        Debug.Log($"{name} I am hit {other.gameObject.name}.");
    }
}
