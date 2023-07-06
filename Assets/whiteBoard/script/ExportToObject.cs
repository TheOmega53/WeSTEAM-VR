using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject sourceObject;
    public GameObject cubeObject;
    public GameObject cylinderObject;

    void Start()
    {
        Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();
        cubeRenderer.enabled = false;
        
        Renderer cylinderRenderer = cylinderObject.GetComponent<Renderer>();
        cylinderRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ExportAndAssignTexture();
    }
    
    public void ExportAndAssignTextureCube()
    { 
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        Material sourceMaterial = sourceRenderer.material;
        Texture sourceTexture = sourceMaterial.mainTexture;
        Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();
        cubeRenderer.enabled = true;
        Material cubeMaterial = cubeRenderer.material;
        cubeMaterial.mainTexture = sourceTexture;
    }
    public void ExportAndAssignTextureCylinder()
    { 
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        Material sourceMaterial = sourceRenderer.material;
        Texture sourceTexture = sourceMaterial.mainTexture;
        Renderer cylinderRenderer = cylinderObject.GetComponent<Renderer>();
        cylinderRenderer.enabled = true;
        Material cylinderMaterial = cylinderRenderer.material;
        cylinderMaterial.mainTexture = sourceTexture;
    }
}
