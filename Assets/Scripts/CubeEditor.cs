// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the Scene is changed to a
// different Scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.


using UnityEngine;

[ExecuteInEditMode] // apply script behavior in editor
[SelectionBase] // select the whole object in editor instead of its individual parts when selected
[RequireComponent(typeof(WayPoint))] // make the script dependent to other script
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
        //finds the specified component in the object
        TextMesh cubeText = GetComponentInChildren<TextMesh>();

        string cubeName = GridPosX()
                          + "," + 
                          GridPosZ();
        
        cubeText.text = cubeName;
        gameObject.name = cubeName;
    }

    private void SnapObjectPosition()
    {
        int gridSize = wayPoint.GetGridsize();
        transform.position = new Vector3(
            GridPosX() * gridSize,
            0f,
            GridPosZ() * gridSize); ;
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