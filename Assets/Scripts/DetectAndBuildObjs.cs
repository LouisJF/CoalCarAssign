using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectAndBuildObjs : MonoBehaviour
{
    public GameObject BuiltSpace;

    //ObjectsInTrigger is the list of the objects on the table, objectsBuilt is a list of the objects on the build floor, they are paired by having the same index val
    static public List<GameObject> ObjectsInTrigger;
    List<GameObject> objectsBuilt;
    Transform builtSpaceTrans;
     
    // Start is called before the first frame update
    void Start()
    {
        ObjectsInTrigger = new List<GameObject>();
        objectsBuilt = new List<GameObject>();
        builtSpaceTrans = BuiltSpace.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //update position of objs on the build floor to the match those of the ones on the table
        for (int i = 0; i < ObjectsInTrigger.Count; i++) 
        {
            objectsBuilt[i].transform.position = ((ObjectsInTrigger[i].transform.position - this.transform.position)*20)+builtSpaceTrans.position;
            objectsBuilt[i].transform.rotation = ObjectsInTrigger[i].transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //create a new cube on the build floor 
        ObjectsInTrigger.Add(other.gameObject);
        GameObject newObj=GameObject.Instantiate(other.gameObject);

        //pair the new cube to the one on the table and remove useless components
        newObj.transform.position = ((other.transform.position-this.transform.position)*20)+builtSpaceTrans.position;
        newObj.transform.localScale *= 20;
        newObj.layer = 0;
        Destroy(newObj.GetComponent<XRGrabInteractable>());
        Destroy(newObj.GetComponent<Rigidbody>());
        objectsBuilt.Add(newObj);
    }
    private void OnTriggerExit(Collider other)
    {
        //if an object leaves the build  table, remove the paired object from the build floor
        int i = ObjectsInTrigger.IndexOf(other.gameObject);
        ObjectsInTrigger.RemoveAt(i);
        Destroy(objectsBuilt[i]);
        objectsBuilt.RemoveAt(i);
    }
}
