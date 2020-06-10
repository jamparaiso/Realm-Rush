using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WayPoint startWaypoint, endWayPoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

    //let the game know of the directions and save it on a list
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    


    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbor();
    }

    private void ExploreNeighbor()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploreCoordinate = startWaypoint.GetGridPos() + direction;

            if (grid.ContainsKey(exploreCoordinate))
            {
                grid[exploreCoordinate].SetTopColor(Color.blue);
            }
            else
            {
                Debug.Log("Block Doesnt Exist");
            }


            //explore nearby nodes
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>(); // find all objects that has WayPoint Script and put in on Array list of class Waypoint

        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.white);
            }

        }
        print("Added " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
