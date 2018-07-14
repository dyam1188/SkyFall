using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls enemy spawn pattern using file reading
//attached to Game -> Script Holder - Game
public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private TextAsset file;

    [SerializeField]
    private GameObject[] enemyArray = new GameObject[3];

    int dataAmount = 3;                                         //amount of elements per line in txt file
    List<GameObject> enemiesToSpawn = new List<GameObject>();   //list to hold all lines' element 0
    List<float> xPositions = new List<float>();                 //                                1
    List<float> spawnTimes = new List<float>();                 //                                2

    List<string> eachLine = new List<string>();

    bool endOfFile;

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
                    spawnTimes.Add(float.Parse(eachLine[i]));
                    break;
            }
        }

        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < eachLine.Count / dataAmount; i++)
        {
            Instantiate(enemiesToSpawn[i], new Vector3(xPositions[i], enemiesToSpawn[i].transform.position.y, enemiesToSpawn[i].transform.position.z), enemiesToSpawn[i].transform.rotation);
            yield return new WaitForSeconds(spawnTimes[i]);
        }

        endOfFile = true;
    }
}
