using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isAnsweringQuestion = false;
    float timerVal;
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToReviewAnswer = 4f;
    public bool loadNextQuestion;
    public float fillFraction;


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        
    }

    public void CancelTimer() {
        timerVal = 0;
    }

    void UpdateTimer() {
        timerVal -= Time.deltaTime;

        if (isAnsweringQuestion) {
            if (timerVal > 0) {
                fillFraction = timerVal / timeToCompleteQuestion;
            } else {
                isAnsweringQuestion = false;
                timerVal = timeToReviewAnswer;
            }
        }
        else {
            if (timerVal > 0) {
                fillFraction = timerVal / timeToReviewAnswer;
            } else {
                isAnsweringQuestion = true;
                timerVal = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }



        Debug.Log(isAnsweringQuestion + ": " + timerVal + " = " + fillFraction);

    }
}
