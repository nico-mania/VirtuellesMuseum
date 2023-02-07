using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Answers : MonoBehaviour
{
   public bool isCorrect = false;
   public QuizManager quizManager;

   [SerializeField] public Color startColor;

   private void Start()
   {
      startColor = GetComponent<RawImage>().color;
   }

   public void Answer()
   {
      if (isCorrect)
      {
         GetComponent<RawImage>().color = Color.green;
         Debug.Log("Correct");
         quizManager.CorrectAnswer();
      }
      else
      {
         GetComponent<RawImage>().color = Color.red;
         Debug.Log("Wrong");
         quizManager.WrongAnswer();
      }
   }
}
