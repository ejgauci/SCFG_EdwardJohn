using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMovementScript : MonoBehaviour
{
    public int up;
    public int down;
    public bool XAxis;
    private Vector3 origin;
    Vector3 originAdd;
    Vector3 originSubt;

    private void Start()
    {
        origin = this.transform.position;

        if (XAxis)
        {
            originAdd = origin + new Vector3(up, 0, 0);
            originSubt = origin - new Vector3(down, 0, 0);
        }
        else
        {
            originAdd = origin + new Vector3(0, up, 0);
            originAdd = origin - new Vector3(0, down, 0);
        }

        StartCoroutine(moveObs());
    }

    IEnumerator moveObs()
    {
        while (true)
        {
            for(int i=0; i<up; i++)
            {
               //print("moving towards: " + originAdd);
                this.transform.position = Vector3.MoveTowards(this.transform.position, originAdd, 1f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < up; i++)
            {
                //print("moving towards: " + origin);
                this.transform.position = Vector3.MoveTowards(this.transform.position, origin, 1f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < down; i++)
            {
                //print("moving towards: " + originAdd);
                this.transform.position = Vector3.MoveTowards(this.transform.position, originAdd, 1f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < down; i++)
            {
                //print("moving towards: " + origin);
                this.transform.position = Vector3.MoveTowards(this.transform.position, origin, 1f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}
