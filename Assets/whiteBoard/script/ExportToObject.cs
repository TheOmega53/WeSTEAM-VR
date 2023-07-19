using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject sourceObject;
    public GameObject cubeObject;
    public GameObject cylinderObject;
    public GameObject sphereObject;
    public GameObject capsuleObject;


    void Start()
    {
        Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();
        cubeRenderer.enabled = false;
        
        Renderer cylinderRenderer = cylinderObject.GetComponent<Renderer>();
        cylinderRenderer.enabled = false;
        
        Renderer sphereRenderer = sphereObject.GetComponent<Renderer>();
        sphereRenderer.enabled = false;
        
        Renderer capsuleRenderer = capsuleObject.GetComponent<Renderer>();
        capsuleRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ExportAndAssignTexture();
    }
    
    public void ExportAndAssignTextureCube()
    {
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();
        if (sourceRenderer != null && cubeRenderer != null)
        {
            Material sourceMaterial = sourceRenderer.sharedMaterial;
            Material copiedMaterial =new Material(sourceMaterial);
            cubeRenderer.enabled = true;
            cubeRenderer.sharedMaterial = copiedMaterial;
        }

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
    public void ExportAndAssignTextureSphere()
    { 
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        Material sourceMaterial = sourceRenderer.material;
        Texture sourceTexture = sourceMaterial.mainTexture;
        Renderer sphereRenderer = sphereObject.GetComponent<Renderer>();
        sphereRenderer.enabled = true;
        Material sphereMaterial = sphereRenderer.material;
        sphereMaterial.mainTexture = sourceTexture;
    }
    public void ExportAndAssignTextureCapsule()
    { 
        Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        Material sourceMaterial = sourceRenderer.material;
        Texture sourceTexture = sourceMaterial.mainTexture;
        Renderer capsuleRenderer = capsuleObject.GetComponent<Renderer>();
        capsuleRenderer.enabled = true;
        Material capsuleMaterial = capsuleRenderer.material;
        capsuleMaterial.mainTexture = sourceTexture;
    }
    
}
