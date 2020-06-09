// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the Scene is changed to a
// different Scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.

using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase] // select the whole object in editor instead of its individual parts when selected
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    WayPoint wayPoint;

    void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        SnapObjectPosition();
        UpdateCubeLabel();
    }

    private void UpdateCubeLabel()
    {
        TextMesh cubeText = GetComponentInChildren<TextMesh>();
        int gridSize = wayPoint.GetGridsize();

        string cubeName = GridPosX() / gridSize + "," + GridPosZ() / gridSize;
        
        cubeText.text = cubeName;
        gameObject.name = cubeName;
    }

    private void SnapObjectPosition()
    {
        transform.position = new Vector3(GridPosX(), 0f, GridPosZ()); ;
    }

    private float GridPosX()
    {
        Vector3 gridPos;
        gridPos.x = wayPoint.GetGridPos().x;
        return gridPos.x;
    }

    private float GridPosZ()
    {
        Vector3 gridPos;
        gridPos.z = wayPoint.GetGridPos().y;
        return gridPos.z;
    }
}