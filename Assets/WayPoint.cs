using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridsize()
    {
        return gridSize;
    }

    public Vector2 GetGridPos()
    {
        int xPos, zPos;

        xPos = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        zPos = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        return new Vector2(xPos,zPos);
    }
}
