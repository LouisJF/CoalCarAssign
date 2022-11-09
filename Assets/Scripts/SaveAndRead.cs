using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndRead : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> gameObjs;
    public GameObject ObjToBuild;
    public bool Run = false;
    void Start()
    {
        //load all the objects from file to the table on startup
        ReadString();
    }

    // Update is called once per frame
    void Update()
    {
        //save all the objects on the table when touched
        if (Run)
        {
            WriteString();
            Run = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Run = true;
    }

    public void WriteString()

    {
        //if theres no objects on the table, dont save anything
        if (DetectAndBuildObjs.ObjectsInTrigger == null)
            return;

        gameObjs = DetectAndBuildObjs.ObjectsInTrigger;

        string path = Application.persistentDataPath + "/save.txt";

        //clear file to write in new info
        File.Create(path).Close();
        StreamWriter writer = new StreamWriter(path, true);

       
        //write the positons and rotations for each object on the build table
        for (int i = 0; i < gameObjs.Count; i++)
        {
            writer.WriteLine(gameObjs[i].transform.position);
            writer.WriteLine(gameObjs[i].transform.rotation);

        }

        writer.Close();
  
    }

    public void ReadString()

    {

        string path = Application.persistentDataPath + "/save.txt";

        //Read the text from directly from the test.txt file

        StreamReader reader = new StreamReader(path);

        //load each line of data into a string
        string data = "";
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            data += line;
        }

        reader.Close();

        //format string so it can be parsed
        data = data.Replace('(', ' ');
        data = data.Replace(')', ',');
        var lines = data.Split(",", System.StringSplitOptions.RemoveEmptyEntries);

        //parse string into floats
        float[] dataNums = new float[lines.Length];
        for (int i = 0; i < lines.Length; i++) 
        {
            dataNums[i]= float.Parse(lines[i]);
        }

        //convert floats into new cubes with positions and rotations as the same
        for (int i = 0; i < dataNums.Length; i += 7) 
        {
            GameObject newObj= GameObject.Instantiate(ObjToBuild);
            newObj.transform.position = new Vector3(dataNums[i],dataNums[i+1],dataNums[i+2]);
            newObj.transform.rotation = new Quaternion(dataNums[i+3],dataNums[i+4],dataNums[i+5],dataNums[i+6]);
        }
    }

}

