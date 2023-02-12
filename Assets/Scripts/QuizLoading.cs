using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizLoading : MonoBehaviour
{
    private bool isLoaded = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync("QuizScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || isLoaded == false)
        {
            SceneManager.LoadScene("QuizScene", LoadSceneMode.Additive);
            isLoaded = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || isLoaded == true)
        {
            SceneManager.UnloadSceneAsync("QuizScene");
            isLoaded = false;
        }
    }
}
