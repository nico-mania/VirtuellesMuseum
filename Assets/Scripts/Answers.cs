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
         GetComponent<RawImage>().color = new Color(0.3055802f, 0.5943396f, 0.3055802f, 1f);
         Debug.Log("Correct");
         quizManager.CorrectAnswer();
      }
      else
      {
         GetComponent<RawImage>().color = new Color(0.5943396f, 0.3055802f, 0.3055802f, 1f);
         Debug.Log("Wrong");
         quizManager.WrongAnswer();
      }
   }
}
