using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusic : MonoBehaviour
{
    void Awake() {
        int numMusicPlayers = FindObjectsOfType<SingletonMusic>().Length;
        if (numMusicPlayers > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
