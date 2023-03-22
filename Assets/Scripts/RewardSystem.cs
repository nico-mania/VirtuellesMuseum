using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private Material whiteMat, bronzeMat, silverMat, goldMat;

    [SerializeField] private GameObject whiteSkin, bronzeSkin, silverSkin, goldSkin;
    
    [SerializeField] private GameObject leftHand;
    private Renderer leftHandRenderer;
    [SerializeField] private GameObject rightHand;
    private Renderer rightHandRenderer;
    
    void Start()
    {
        leftHandRenderer = leftHand.GetComponent<Renderer>();
        rightHandRenderer = rightHand.GetComponent<Renderer>();
    }
    
    void Update()
    {
        //spawns new skin based on spawnint
        switch (QuizManager.spawnint)
        {
            case 3:
                goldSkin.SetActive(true);
                silverSkin.SetActive(true);
                bronzeSkin.SetActive(true);
                break;
            case 2:
                silverSkin.SetActive(true);
                bronzeSkin.SetActive(true);
                break;
            case 1:
                bronzeSkin.SetActive(true);
                break;
            default:
                whiteSkin.SetActive(true);
                break;
        }
    }

    public void ChangeMaterialWhite()
    {
        leftHandRenderer.material = whiteMat;
        rightHandRenderer.material = whiteMat;
    }
    
    public void ChangeMaterialBronze()
    {
        leftHandRenderer.material = bronzeMat;
        rightHandRenderer.material = bronzeMat;
    }
    
    public void ChangeMaterialSilver()
    {
        leftHandRenderer.material = silverMat;
        rightHandRenderer.material = silverMat;
    }
    
    public void ChangeMaterialGold()
    {
        leftHandRenderer.material = goldMat;
        rightHandRenderer.material = goldMat;
    }
}
