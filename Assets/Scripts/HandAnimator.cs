using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty gripAnimation;

    [SerializeField] private Animator handAnimator;

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        
        float gripValue = gripAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
