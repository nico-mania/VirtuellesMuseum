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
    [SerializeField] private TMP_Text answerProgress, quizScore;
    [SerializeField] private Image Painting;

    public static int spawnint = 0; //determines which level of reward is given
    private float totalQuestions = 0;
    private float rightAnswers = 0;
    private float currentAnswer = 0;

    private void Start()
    {
        totalQuestions = QnA.Count;
        NextQuestion();
        RetryButton.onClick.AddListener(Retry);
    }

    public void Retry()
    {
        QuizPanel.SetActive(true);
        RetryPanel.SetActive(false);
        
        //reload quizscene
        SceneManager.UnloadSceneAsync(1); 
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
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
            //chooses a random next question out of QnA List
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            Painting.sprite = QnA[currentQuestion].Painting;
            SetAnswers();
            currentAnswer++;
            answerProgress.text = currentAnswer + "/" + totalQuestions;
        }
        else
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        QuizPanel.SetActive(false);
        RetryPanel.SetActive(true);
        quizScore.text = rightAnswers + "/" + totalQuestions;
        float percentage = rightAnswers / totalQuestions;
        switch (percentage)
        {
            case 1.0f:
                spawnint = 3;
                break;
            case var p when p >= 0.75f:
                spawnint = 2;
                break;
            case var p when p >= 0.5f:
                spawnint = 1;
                break;
            default:
                spawnint = 0;
                break;
        }
    }
}
