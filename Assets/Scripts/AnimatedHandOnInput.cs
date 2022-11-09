using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatedHandOnInput : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    public Animator handAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = pinchAnimationAction.action.ReadValue<float>();
        float gripVal = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);
        handAnimator.SetFloat("Grip", gripVal);
    }
}
