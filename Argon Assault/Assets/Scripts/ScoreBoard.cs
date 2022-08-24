using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    
    public void IncreaseScore(int amountToIncrease) {
        score += amountToIncrease;
        Debug.Log($"Score: {score}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
