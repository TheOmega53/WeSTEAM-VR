using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class MapMaterial : MonoBehaviour
{
    public void UpdateMaterial(GameObject sourceObject)
    {
        GetComponent<Renderer>().material.mainTexture = sourceObject.GetComponent<Renderer>().material.mainTexture;
    }
}
