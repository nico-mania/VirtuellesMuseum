using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    [SerializeField] private GameObject QuizPanel;
    [SerializeField] private GameObject RetryPanel;
    [SerializeField] private Button RetryButton;
    [SerializeField] private TMP_Text QuestionText;
    [SerializeField] private TMP_Text quizScore;
    
    private int totalQuestions = 0;
    private int rightAnswers = 0;

    private void Start()
    {
        totalQuestions = QnA.Count;
        NextQuestion();
        RetryButton.onClick.AddListener(Retry);
        //fixt momentan fehler indem die buttons nach scenen neustart nicht wieder weiß werden
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<RawImage>().color =  Color.white;
        }
    }

    private void GameOver()
    {
        QuizPanel.SetActive(false);
        RetryPanel.SetActive(true);
        quizScore.text = rightAnswers + "/" + totalQuestions;
    }

    public void Retry()
    {
        Debug.Log("Retry");
        QuizPanel.SetActive(true);
        RetryPanel.SetActive(false);
        SceneManager.UnloadSceneAsync("QuizScene");
        SceneManager.LoadScene("QuizScene", LoadSceneMode.Additive);
    }
    
    public void CorrectAnswer()
    {
        rightAnswers += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNextQuestion());
    }

    public void WrongAnswer()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNextQuestion());
    }

    private IEnumerator WaitForNextQuestion()
    {
        yield return new WaitForSeconds(0.5f);
        NextQuestion();
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent <RawImage>().color = options[i].GetComponent <Answers>().startColor;
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
            
            if (QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }
    private void NextQuestion()
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
            GameOver();
        }
    }
}
