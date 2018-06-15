using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

//controls enemy spawn pattern using file reading
//attached to Game -> Script Holder - Game
public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private TextAsset file;             //WaveHandler.txt

    [SerializeField]
    private GameObject[] enemyArray = new GameObject[3];

    int dataAmount = 2;                                                                                 //amount of elements per line in txt file
    List<GameObject> enemiesToSpawn = new List<GameObject>();                                           //list to hold all lines' element 0
    List<float> xPositions = new List<float>();                                                         //                                1
    List<float> spawnTimes = new List<float>();                                                         //                                2

    List<string> eachLine = new List<string>();

    int enemyCount;
    bool isDelaying;

    void Start()
    {
        string entireFile = file.text;                                                                      //converts the entire file into one entire string
        string[] delimiters = new string[] { "\n", ", " };                                                  //sets where to split the string
        string[] splitFile = entireFile.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);    //splits the string

        eachLine.AddRange(splitFile);                                                                       //adds each split section to its own list index

        for (int i = 0; i < eachLine.Count; i++)    //loop through all elements in the split file
        {
            if (eachLine[i][0] != '/')              //if the line isn't a comment, tell the game where to spawn what enemy
            {
                switch (i % dataAmount)             //for case descriptions, refer to txt file
                {
                    case 0:
                        enemiesToSpawn.Add(enemyArray[System.Int32.Parse(eachLine[i])]);
                        break;
                    case 1:
                        xPositions.Add(float.Parse(eachLine[i]));
                        break;
                        //case 2:
                        //    break;
                }
            }
        }

        for (int i = 0; i < eachLine.Count / dataAmount - 1; i++)
        {
            Spawn(enemiesToSpawn[i], xPositions[i]);
            //isDelaying = true;
            //StartCoroutine(Delay(1f));
        }
    }

    void Update()
    {
        
    }

    void Spawn(GameObject enemyToSpawn, float xPosition)
    {
        Instantiate(enemyToSpawn, new Vector3(xPosition, enemyToSpawn.transform.position.y, enemyToSpawn.transform.position.z), enemyToSpawn.transform.rotation);
        enemyCount++;
    }

    IEnumerator Delay(float time)
    {
        Debug.Log("running delay...");
        yield return new WaitForSeconds(time);
        Debug.Log("delay finished.");
        isDelaying = false;
    }


}
