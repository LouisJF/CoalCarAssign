using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteInteractables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if an interactable touches this, delete it
        if (other.GetComponent<XRGrabInteractable>() != null) 
        {
            Destroy(other.gameObject);
        }
    }
}
