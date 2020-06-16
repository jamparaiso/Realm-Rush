using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelVisibility : MonoBehaviour
{

    public void DisableCubeLabel()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    public void EnableCubeLabel()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.enabled = true;
    }

}
