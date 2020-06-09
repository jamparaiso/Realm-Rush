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

    public Vector2Int GetGridPos()
    {

        //xPos = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        //zPos = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh =  transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }
}
