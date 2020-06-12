using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isExplored = false;
    public WayPoint exploredFrom;
    const int gridSize = 10;

    public int GetGridsize()
    {
        return gridSize;
    }

    //returns the position of the object where the script is attached to
    //returns different values for each object where it is attached to
    public Vector2Int GetGridPos() 
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh =  transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }

}
