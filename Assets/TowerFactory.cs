using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void addTower(WayPoint wayPoint) 
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateTower(wayPoint);
        }
        else
        {
            MoveExistingTower(wayPoint);
        }

    }

    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue(); // removes the first tower on the queue

        oldTower.baseWaypoint.isPlaceable = true; // set the block where the tower stands placeable
        newBaseWaypoint.isPlaceable = false; //makes the selected block unplaceable

        oldTower.baseWaypoint = newBaseWaypoint; //replace the old block to the new selected block
        oldTower.transform.position = newBaseWaypoint.transform.position; // moves the first tower in queue to the selected block

        towerQueue.Enqueue(oldTower); // add the tower to the end of the queue

    }

    private void InstantiateTower(WayPoint wayPoint)
    {
        //create tower on the block
        var tower = Instantiate(towerPrefab, wayPoint.transform.position, Quaternion.identity,gameObject.transform);
        tower.baseWaypoint = wayPoint; // let the tower know what block does it stand on
        wayPoint.isPlaceable = false;
        towerQueue.Enqueue(tower);

    }
}
