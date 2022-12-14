using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    
    float timeDelay = 1f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel() {
        yield return new WaitForSecondsRealtime(timeDelay);
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int newIdx = currentSceneIdx+1;

        if (newIdx == SceneManager.sceneCountInBuildSettings) {
            newIdx = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(newIdx);
    }
}
