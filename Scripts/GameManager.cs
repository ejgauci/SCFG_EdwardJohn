using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void scan()
    {
        GameObject.Find("AStarGrid").GetComponent<AstarPath>().Scan();

        print("Scanned");
    }

    public void addObstacle()
    {

        print("Obstacle Added");
    }

    public void addAI()
    {

        print("AI Added");
    }

    public void StartAI()
    {
        print("AI Started");
    }



}
