﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WayPoint startWaypoint, endWayPoint;
    [SerializeField] bool isRunning = true;
    //used dictionary to save blocks information because we need its location and the object where the script is attached to hence key and value pair
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> blockQueue = new Queue<WayPoint>();
    List<WayPoint> path = new List<WayPoint>(); //list of all object that have waypoint script attached to
    WayPoint searchCenter;

    public bool isCalled = false;

    //let the game know of the directions and save it on a list
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath() 
    {
        //checks if a path is created before we initialize this method
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            ColorStartAndEnd();
            CreatePath();
        }
        return path;
    }
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>(); // find all objects that has WayPoint Script and put in on Array list of class Waypoint

        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping blocks on:  " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint); //adds the block in the dictionary
                waypoint.SetTopColor(Color.white);
            }
        }
    }
    private void BreadthFirstSearch()
    {
        // add the starting block on the queue
        blockQueue.Enqueue(startWaypoint);

        while (blockQueue.Count > 0 && isRunning)
        {
            //remove the first block in queue
            //see FIFO
            searchCenter = blockQueue.Dequeue();
            searchCenter.isExplored = true;

            HaltEndIfFound();
            ExploreNeighbor();
        }
    }
    private void HaltEndIfFound()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }
    private void ExploreNeighbor()
    {
        if (!isRunning) { return; } //stops the neighbour block search

        foreach (Vector2Int direction in directions)
        { 
            // find all blocks around the current block based on the directions[]
            Vector2Int blockNeighbour = searchCenter.GetGridPos() + direction;

            //this logic is applicable on this because it uses coordinates in which coordinates doesnt repeat
            if (grid.ContainsKey(blockNeighbour))  //checks if there is a block on the same coordidates
            {
                QueueNewNeighbour(blockNeighbour);
            }
        }

    }
    private void QueueNewNeighbour(Vector2Int blockNeighbour)
    {
        WayPoint neighbourBlock = grid[blockNeighbour];

        if (!neighbourBlock.isExplored && !blockQueue.Contains(neighbourBlock))
        {
            blockQueue.Enqueue(neighbourBlock); // adds the neighbour block on queue
            neighbourBlock.exploredFrom = searchCenter; // log where the neighbour block explored from
        }
    }
    private void CreatePath()
    {
        markAsPath(endWayPoint);
        WayPoint previous = endWayPoint.exploredFrom;

        while (previous != startWaypoint)
        {
            previous.SetTopColor(Color.blue);
            markAsPath(previous);
            previous = previous.exploredFrom;
            //todo have a catch method when the endpoint is isolated
        }
        markAsPath(startWaypoint);
        path.Reverse();
    }
    private void markAsPath(WayPoint wayPoint)
    {
        //makes the block unplaceable
        path.Add(wayPoint);
        wayPoint.isPlaceable = false;
    }
    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

}
