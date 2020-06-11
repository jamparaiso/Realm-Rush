using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WayPoint startWaypoint, endWayPoint;
    [SerializeField] bool isRunning = true; // todo make private
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    WayPoint searchCenter;

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
        PathFind();
        ColorStartAndEnd();
        //ExploreNeighbor();
    }

    private void PathFind()
    {
        // add the starting block coordinate on queue
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            //remove the first block in queue
            //see FIFO
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            //print("Searching from: " + searchCenter); // todo remove log

            HaltEndIfFound();
            ExploreNeighbor();
        }
        print("Finished pathfinding");
    }

    private void HaltEndIfFound()
    {
        if (searchCenter == endWayPoint)
        {
            print("End point found!"); // todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbor()
    {
        if (!isRunning) { return; } //endpoint found;

        foreach (Vector2Int direction in directions)
        { 
            // find all blocks around the current block based on the directions[]
            Vector2Int blockNeighbour = searchCenter.GetGridPos() + direction;
            
            //checks if block on the same coordidates
            //this logic is applicable on this because it uses coordinates in which coordinates doesnt repeat
            if (grid.ContainsKey(blockNeighbour))
            {
                QueueNewNeighbour(blockNeighbour);
            }
            else
            {
                //Debug.Log("Block Doesnt Exist");
            }

        }
    }

    private void QueueNewNeighbour(Vector2Int blockNeighbour)
    {
        WayPoint neighbourBlock = grid[blockNeighbour];

        if (!neighbourBlock.isExplored && !queue.Contains(neighbourBlock))
        {
            neighbourBlock.SetTopColor(Color.blue);
            queue.Enqueue(neighbourBlock); // adds the neighbour block on queue
            neighbourBlock.exploredFrom = searchCenter; // log where the neighbour block explored from

            //print("Queueing: " + neighbourBlock);
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
