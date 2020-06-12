using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    float dwellTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path ) //move enemy using coroutines
    {
        //print("Starting Patrol...");

        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print("Visiting Block: " + wayPoint.name);
           yield return new WaitForSeconds(dwellTime);
        }

        print("Ending Patrol..");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
