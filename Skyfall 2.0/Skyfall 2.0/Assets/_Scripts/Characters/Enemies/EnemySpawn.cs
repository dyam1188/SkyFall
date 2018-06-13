using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private TextAsset file;             //WaveHandler.txt

    [SerializeField]
    private GameObject[] enemyArray = new GameObject[3];

    int enemyCount;

    void Start()
    {
        List<GameObject> enemiesToSpawn = new List<GameObject>();
        List<float> xPositions = new List<float>();

        string entireFile = file.text;                                                                      //converts the entire file into one entire string
        string[] delimiters = new string[] { "\n", ", " };      
        string[] splitFile = entireFile.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);    //separates the string by line breaks and commas

        List<string> eachLine = new List<string>();
        eachLine.AddRange(splitFile);                                                                       //adds each split section to its own list index
        int dataAmount = 2;

        for (int i = 0; i < eachLine.Count; i++)    //loop through all elements in the split file
        {
            if (eachLine[i][0] != '/')              //if the line isn't a comment, tell the game where to spawn what enemy
            {
                switch (i % dataAmount)
                {
                    case 0:                         //for case descriptions, refer to txt file
                        enemiesToSpawn.Add(enemyArray[System.Int32.Parse(eachLine[i])]);
                        break;
                    case 1:
                        xPositions.Add(float.Parse(eachLine[i]));
                        break;
                }
            }
        }

        for (int i = 0; i < eachLine.Count / dataAmount - 1; i++)
        {
            Spawn(enemiesToSpawn[i], xPositions[i]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(enemyCount);
        }
    }

    void Spawn(GameObject enemyToSpawn, float xPosition)
    {
        Instantiate(enemyToSpawn, new Vector3(xPosition, 6f, 1f), enemyToSpawn.transform.rotation);
        enemyCount++;
    }
}
