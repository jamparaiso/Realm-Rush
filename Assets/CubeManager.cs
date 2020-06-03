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
[SelectionBase]
public class CubeManager : MonoBehaviour
{

    [Range(1f,20f)] [SerializeField] float gridSize = 10f;
    TextMesh cubeText;
    Vector3 snapPos;
    string cubeName;

    void Update()
    {
        SnapObjectPosition();
        gameObject.name = UpdateCubeText();
    }

    private string UpdateCubeText()
    {
        cubeText = GetComponentInChildren<TextMesh>();
        cubeName = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        cubeText.text = cubeName;
        return cubeName;
    }

    private void SnapObjectPosition()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}