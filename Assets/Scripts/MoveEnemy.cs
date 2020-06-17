using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    float dwellTime = 1.50f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));

    }

    IEnumerator FollowPath(List<WayPoint> path ) //move enemy using coroutines
    {
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
           yield return new WaitForSeconds(dwellTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
