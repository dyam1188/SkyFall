using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls enemy spawn pattern using file reading
//attached to Game -> Script Holder - Game
public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    TextAsset file;

    [SerializeField]
    GameObject[] enemyArray = new GameObject[4];

    int dataAmount = 4;                                         //amount of elements per line in txt file
    List<GameObject> enemiesToSpawn = new List<GameObject>();   //list to hold all lines' element 0
    List<float> xPositions = new List<float>();                 //                                1
    List<float> yPositions = new List<float>();                 //                                2
    List<float> spawnDelays = new List<float>();                 //                               3

    List<string> eachLine = new List<string>();

    public bool hasBossSpawned;

    void Start()
    {
        string entireFile = file.text;                                                                      //converts the entire file into one entire string
        string[] delimiters = new string[] { "\n", ", " };                                                  //sets where to split the string
        string[] splitFile = entireFile.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);    //splits the string

        foreach (string str in splitFile)
        {
            if (!str.StartsWith("/") && !str.StartsWith("\n") && !str.StartsWith("\r"))
            {
                eachLine.Add(str);                  //adds each split section to its own list index if it's not a comment or empty line
            }
        }

        //adds data in respective lists
        for (int i = 0; i < eachLine.Count; i++)
        {
            switch (i % dataAmount)
            {
                case 0:
                    enemiesToSpawn.Add(enemyArray[System.Int32.Parse(eachLine[i])]);
                    break;
                case 1:
                    xPositions.Add(float.Parse(eachLine[i]));
                    break;
                case 2:
                    yPositions.Add(float.Parse(eachLine[i]));
                    break;
                case 3:
                    spawnDelays.Add(float.Parse(eachLine[i]));
                    break;
            }
        }

        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < eachLine.Count / dataAmount; i++)
        {
            Instantiate(enemiesToSpawn[i], new Vector3(xPositions[i], yPositions[i], enemiesToSpawn[i].transform.position.z), enemiesToSpawn[i].transform.rotation);
            yield return new WaitForSeconds(spawnDelays[i]);
        }

        hasBossSpawned = true;
    }
}
