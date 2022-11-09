using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportRays : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftTeleRay;
    public GameObject rightTeleRay;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if grabbing dont project rays
        leftTeleRay.SetActive(leftCancel.action.ReadValue<float>()==0&&leftActivate.action.ReadValue<float>()>0.1f);
        rightTeleRay.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>()>0.1f);
    }
}
