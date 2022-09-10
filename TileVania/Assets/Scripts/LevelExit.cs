using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    
    float timeDelay = 1f;

    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel() {
        yield return new WaitForSecondsRealtime(timeDelay);
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int newIdx = currentSceneIdx+1;

        if (newIdx == SceneManager.sceneCountInBuildSettings) {
            newIdx = 0;
        }
        SceneManager.LoadScene(newIdx);
    }
}
