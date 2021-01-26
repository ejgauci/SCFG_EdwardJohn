using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject robotAI;
    public GameObject obstacleObject;

    List<Vector3> recordPositions = new List<Vector3> { };

  


    public void scan()
    {
        GameObject.Find("AStarGrid").GetComponent<AstarPath>().Scan();

        print("Scanned");
    }

    public void addObstacle()
    {
        Vector3 randomPos = new Vector3(Random.Range(-49, 49), Random.Range(-49, 49), 0);
        Instantiate(obstacleObject, randomPos, Quaternion.identity);
        recordPositions.Add(randomPos);

        print("Obstacle Added");
    }

    public void addAI()
    {

        print("AI Added");

        Vector3 randomPos = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);

        if (!recordPositions.Contains(randomPos))
        {
            Instantiate(robotAI, randomPos, Quaternion.identity);
        }
    }

    public void StartAI()
    {
        print("AI Started");

        GameObject[] robots = GameObject.FindGameObjectsWithTag("AI");

        foreach(GameObject ai in robots)
        {
            ai.GetComponent<customAIMoveScriptGrid>().enabled = true;
        }
    }



}
