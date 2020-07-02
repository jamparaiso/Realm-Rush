using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isExplored = false;
    public WayPoint exploredFrom;
    const int gridSize = 10;
    public bool isPlaceable = true;

    [SerializeField] Tower towerPrefab;

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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                spawnTower();
            }
            else
            {
                print("not placeable block");
            }
        }
    }

    private void spawnTower() {
        FindObjectOfType<TowerFactory>().addTower(this);
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh =  transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }

}
