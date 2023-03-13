using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private Button quitGame, yesButton, noButton;
    [SerializeField] private GameObject leavePanel, checkPanel;

    public void SwitchPanel()
    {
        if (leavePanel.activeSelf)
        {
            leavePanel.SetActive(false);
            checkPanel.SetActive(true);
        }
        else
        {
            checkPanel.SetActive(false);
            leavePanel.SetActive(true);
        }
    }
    
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
