using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
   public bool isCorrect = false;
   public QuizManager quizManager;

   public void Answer()
   {
      if (isCorrect)
      {
         Debug.Log("Correct");
         quizManager.correctAnswer();
      }
      else
      {
         Debug.Log("Wrong");
         quizManager.correctAnswer();
      }
   }
}
