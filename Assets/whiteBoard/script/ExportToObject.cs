using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sourceObject;
    public GameObject destinationObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExportAndAssignTexture();
    }
    public void ExportAndAssignTexture()
    {
        // Code for exporting and assigning the texture
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
    
        // Get the material of the source renderer
        Material sourceMaterial = sourceRenderer.material;
    
        // Get the texture from the source material
        Texture sourceTexture = sourceMaterial.mainTexture;
    
        // Get the renderer component of the destination object
        Renderer destinationRenderer = destinationObject.GetComponent<Renderer>();
    
        // Get the material of the destination renderer
        Material destinationMaterial = destinationRenderer.material;
    
        // Assign the texture to the destination material
        destinationMaterial.mainTexture = sourceTexture;
    }
}
