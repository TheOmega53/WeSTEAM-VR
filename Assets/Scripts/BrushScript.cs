using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushScript : MonoBehaviour
{
    public GameObject brushPrefab; // Prefab for the brush
    public float brushSize = 0.1f; // Size of the brush
    public float brushStrength = 0.5f; // Strength of the brush
    // Start is called before the first frame update
     private GameObject currentBrush; // Reference to the current brush instance
    private RaycastHit hitInfo; // Stores information about the hit point
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the ray hits any collider
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Check if the ray hits a mesh collider
                if (hitInfo.collider is MeshCollider meshCollider)
                {
                    // Create a new brush instance at the hit point
                    if (currentBrush == null)
                    {
                        currentBrush = Instantiate(brushPrefab, hitInfo.point, Quaternion.identity);
                        currentBrush.transform.localScale = Vector3.one * brushSize;
                    }

                    // Move the brush to the hit point
                    currentBrush.transform.position = hitInfo.point;

                    // Modify the mesh vertices using brush strength
                    Mesh mesh = meshCollider.sharedMesh;
                    Vector3[] vertices = mesh.vertices;
                    int[] triangles = mesh.triangles;
                    Vector3 brushPosition = currentBrush.transform.position;

                    for (int i = 0; i < triangles.Length; i += 3)
                    {
                        Vector3 v1 = vertices[triangles[i]];
                        Vector3 v2 = vertices[triangles[i + 1]];
                        Vector3 v3 = vertices[triangles[i + 2]];

                        Vector3 barycentricCoordinate = hitInfo.barycentricCoordinate;
                        Vector3 pointOnTriangle = v1 * barycentricCoordinate.x + v2 * barycentricCoordinate.y + v3 * barycentricCoordinate.z;

                        float distance = Vector3.Distance(pointOnTriangle, brushPosition);
                        if (distance <= brushSize)
                        {
                            float strength = 1f - (distance / brushSize);
                            vertices[triangles[i]] += hitInfo.normal * strength * brushStrength;
                            vertices[triangles[i + 1]] += hitInfo.normal * strength * brushStrength;
                            vertices[triangles[i + 2]] += hitInfo.normal * strength * brushStrength;
                        }
                    }

                    // Update the modified vertices in the mesh
                    mesh.vertices = vertices;
                    meshCollider.sharedMesh = mesh;
                }
            }
        }
        else
        {
            // Destroy the brush instance when the mouse button is released
            if (currentBrush != null)
            {
                Destroy(currentBrush);
                currentBrush = null;
            }
        }
    }
}
