using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject sourceObject2;
    public GameObject cubeObject2;
    public GameObject cylinderObject2;
    public GameObject sphereObject2;
    public GameObject capsuleObject2;


    void Start()
    {
        Renderer cubeRenderer2 = cubeObject2.GetComponent<Renderer>();
        cubeRenderer2.enabled = false;
        
        Renderer cylinderRenderer2 = cylinderObject2.GetComponent<Renderer>();
        cylinderRenderer2.enabled = false;
        
        Renderer sphereRenderer2 = sphereObject2.GetComponent<Renderer>();
        sphereRenderer2.enabled = false;
        
        Renderer capsuleRenderer2 = capsuleObject2.GetComponent<Renderer>();
        capsuleRenderer2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ExportAndAssignTexture();
    }
    
    public void ExportAndAssignTextureCube2()
    {
        Renderer sourceRenderer2 = sourceObject2.GetComponent<Renderer>();
        Renderer cubeRenderer2 = cubeObject2.GetComponent<Renderer>();
        if (sourceRenderer2 != null && cubeRenderer2 != null)
        {
            Material sourceMaterial2 = sourceRenderer2.sharedMaterial;
            Material copiedMaterial2 =new Material(sourceMaterial2);
            copiedMaterial2.CopyPropertiesFromMaterial(sourceMaterial2);
            cubeRenderer2.enabled = true;
            cubeRenderer2.material = copiedMaterial2;
        }

        sourceRenderer2.enabled = false;
    }
    public void ExportAndAssignTextureCylinder2()
    { 
        Renderer sourceRenderer2 = sourceObject2.GetComponent<Renderer>();
        Material sourceMaterial2 = sourceRenderer2.material;
        Texture sourceTexture2 = sourceMaterial2.mainTexture;
        Renderer cylinderRenderer2 = cylinderObject2.GetComponent<Renderer>();
        cylinderRenderer2.enabled = true;
        Material cylinderMaterial2 = cylinderRenderer2.material;
        cylinderMaterial2.mainTexture = sourceTexture2;
        sourceRenderer2.enabled = false;
    }
    public void ExportAndAssignTextureSphere2()
    { 
        Renderer sourceRenderer2 = sourceObject2.GetComponent<Renderer>();
        Material sourceMaterial2 = sourceRenderer2.material;
        Texture sourceTexture2 = sourceMaterial2.mainTexture;
        Renderer sphereRenderer2 = sphereObject2.GetComponent<Renderer>();
        sphereRenderer2.enabled = true;
        Material sphereMaterial2 = sphereRenderer2.material;
        sphereMaterial2.mainTexture = sourceTexture2;
        sourceRenderer2.enabled = false;
    }
    public void ExportAndAssignTextureCapsule2()
    { 
        Renderer sourceRenderer2 = sourceObject2.GetComponent<Renderer>();
        Material sourceMaterial2 = sourceRenderer2.material;
        Texture sourceTexture2 = sourceMaterial2.mainTexture;
        Renderer capsuleRenderer2 = capsuleObject2.GetComponent<Renderer>();
        capsuleRenderer2.enabled = true;
        Material capsuleMaterial2 = capsuleRenderer2.material;
        capsuleMaterial2.mainTexture = sourceTexture2;
        sourceRenderer2.enabled = false;
    }
    
}
