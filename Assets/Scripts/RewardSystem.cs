using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private Material whiteMat, bronzeMat, silverMat, goldMat;
    
    [SerializeField] private GameObject leftHand;
    private Renderer leftHandRenderer;
    [SerializeField] private GameObject rightHand;
    private Renderer rightHandRenderer;
    void Start()
    {
        leftHandRenderer = leftHand.GetComponent<Renderer>();
        rightHandRenderer = rightHand.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
