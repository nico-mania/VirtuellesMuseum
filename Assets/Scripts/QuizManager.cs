using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionText;

    private void Start()
    {
        generateQuestion();
    }

    public void correctAnswer()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
            
            if (QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }
    private void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions.");
        }
    }
}
