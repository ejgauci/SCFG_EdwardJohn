﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;


public class customAIMoveScriptGrid : MonoBehaviour
{
    //the object that we are using to generate the path
    Seeker seeker;

    //path to follow stores the path
    Path pathToFollow;

    //a reference from the UI to the green box
    public Transform target;

    //a reference to PointGraphObject
    GameObject graphParent;

    //the node of the graph that is going to correspond with the green box
    GameObject targetNode;

    public List<Transform> obstacleNodes;


    // Start is called before the first frame update
    void Start()
    {
        //here the robot finds the target to go to
        target = GameObject.Find("Target").transform;


        //Debug.Log(this.name);

        //the instance of the seeker attached to this game object
        seeker = GetComponent<Seeker>();


        //node target by name
        targetNode = GameObject.Find("TargetNode");

        //find the parent node of the point graph
         //graphParent = GameObject.Find("PointGraphObject");
        graphParent = GameObject.Find("AStarGrid");
        //we scan the graph to generate it in memory
        graphParent.GetComponent<AstarPath>().Scan();

        //generate the initial path
        pathToFollow = seeker.StartPath(transform.position, target.position);



        //update the graph as soon as you can.  Runs indefinitely
        StartCoroutine(updateGraph());

        //move the red robot towards the green enemy
        StartCoroutine(moveTowardsEnemy(this.transform));
    }



    IEnumerator updateGraph()
    {
        while (true)
        {

      //   targetNode.transform.position = target.position;
            graphParent.GetComponent<AstarPath>().Scan();


            yield return null;

        }

    }

    IEnumerator moveTowardsEnemy(Transform t)
    {

        while (true)
        {

            List<Vector3> posns = pathToFollow.vectorPath;
            //Debug.Log("Positions Count: " + posns.Count);

            for (int counter = 0; counter < posns.Count; counter++)
            {
                // Debug.Log("Distance: " + Vector3.Distance(t.position, posns[counter]));
                if (posns[counter] != null) { 
                    while (Vector3.Distance(t.position, posns[counter]) >= 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, posns[counter], 1f);
                        //since the enemy is moving, I need to make sure that I am following him
                        pathToFollow = seeker.StartPath(t.position, target.position);
                        //wait until the path is generated
                        yield return seeker.IsDone();
                        //if the path is different, update the path that I need to follow
                        posns = pathToFollow.vectorPath;

                      //  Debug.Log("@:" + t.position + " " + target.position + " " + posns[counter]);
                        yield return new WaitForSeconds(0.2f);
                    }

                }
                //keep looking for a path because if we have arrived the enemy will anyway move away
                //This code allows us to keep chasing
                pathToFollow = seeker.StartPath(t.position, target.position);
                yield return seeker.IsDone();
                posns = pathToFollow.vectorPath;
                //yield return null;

            }
            yield return null;
        }
    }



}


