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
   private Color correctColor = new Color(0.3055802f, 0.5943396f, 0.3055802f, 1f);
   private Color falseColor = new Color(0.5943396f, 0.3055802f, 0.3055802f, 1f);

   private void Start()
   {
      startColor = GetComponent<RawImage>().color;
   }

   public void Answer()
   {
      if (isCorrect)
      {
         GetComponent<RawImage>().color = correctColor;
         quizManager.CorrectAnswer();
      }
      else
      {
         GetComponent<RawImage>().color = falseColor;
         quizManager.WrongAnswer();
      }
   }
}
