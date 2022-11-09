using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objToBuild;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //if this is touched, create a new cube
    private void OnTriggerEnter(Collider other)
    {
        GameObject newObj = GameObject.Instantiate(objToBuild);
        newObj.transform.position = (new Vector3(0.44f, 1.3f, 1.76f));
    }
}
