using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int gold = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;

        if (numGameSession > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        livesText.text = playerLives.ToString();
        goldText.text = gold.ToString();
    }

    public void ProcessPlayerDeath() {
        if (playerLives > 1) {
            Invoke("TakeLife", 1f);
        } else {
            Invoke("ResetGameSession", 1f);
        }
    }

    public void IncreaseGold(int pointsToAdd) {
        gold += pointsToAdd;
        goldText.text = gold.ToString();
    }
    
    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject); // destroy this instance of game session
    }

    private void TakeLife()
    {
        playerLives--;
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
        livesText.text = playerLives.ToString();
    }
}
