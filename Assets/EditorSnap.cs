﻿// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the Scene is changed to a
// different Scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.

using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{

    [Range(1f,20f)] [SerializeField] float gridSize = 10f;

    void Update()
    {
        SnapObjectPosition();
    }

    private void SnapObjectPosition()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}