using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject1 : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject sourceObject1;
    public GameObject cubeObject1;
    public GameObject cylinderObject1;
    public GameObject sphereObject1;
    public GameObject capsuleObject1;


    void Start()
    {
        Renderer cubeRenderer1 = cubeObject1.GetComponent<Renderer>();
        cubeRenderer1.enabled = false;
        
        Renderer cylinderRenderer1 = cylinderObject1.GetComponent<Renderer>();
        cylinderRenderer1.enabled = false;
        
        Renderer sphereRenderer1 = sphereObject1.GetComponent<Renderer>();
        sphereRenderer1.enabled = false;
        
        Renderer capsuleRenderer1 = capsuleObject1.GetComponent<Renderer>();
        capsuleRenderer1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ExportAndAssignTexture();
    }
    
    public void ExportAndAssignTextureCube1()
    {
        Renderer sourceRenderer1 = sourceObject1.GetComponent<Renderer>();
        Renderer cubeRenderer1 = cubeObject1.GetComponent<Renderer>();
        if (sourceRenderer1 != null && cubeRenderer1 != null)
        {
            Material sourceMaterial1 = sourceRenderer1.sharedMaterial;
            Material copiedMaterial1 =new Material(sourceMaterial1);
            copiedMaterial1.CopyPropertiesFromMaterial(sourceMaterial1);
            cubeRenderer1.enabled = true;
            cubeRenderer1.material = copiedMaterial1;
        }

        sourceRenderer1.enabled = false;
    }
    public void ExportAndAssignTextureCylinder1()
    { 
        Renderer sourceRenderer1 = sourceObject1.GetComponent<Renderer>();
        Material sourceMaterial1 = sourceRenderer1.material;
        Texture sourceTexture1 = sourceMaterial1.mainTexture;
        Renderer cylinderRenderer1 = cylinderObject1.GetComponent<Renderer>();
        cylinderRenderer1.enabled = true;
        Material cylinderMaterial1 = cylinderRenderer1.material;
        cylinderMaterial1.mainTexture = sourceTexture1;
        sourceRenderer1.enabled = false;
    }
    public void ExportAndAssignTextureSphere1()
    { 
        Renderer sourceRenderer1 = sourceObject1.GetComponent<Renderer>();
        Material sourceMaterial1 = sourceRenderer1.material;
        Texture sourceTexture1 = sourceMaterial1.mainTexture;
        Renderer sphereRenderer1 = sphereObject1.GetComponent<Renderer>();
        sphereRenderer1.enabled = true;
        Material sphereMaterial1 = sphereRenderer1.material;
        sphereMaterial1.mainTexture = sourceTexture1;
        sourceRenderer1.enabled = false;
    }
    public void ExportAndAssignTextureCapsule1()
    { 
        Renderer sourceRenderer1 = sourceObject1.GetComponent<Renderer>();
        Material sourceMaterial1 = sourceRenderer1.material;
        Texture sourceTexture1 = sourceMaterial1.mainTexture;
        Renderer capsuleRenderer1 = capsuleObject1.GetComponent<Renderer>();
        capsuleRenderer1.enabled = true;
        Material capsuleMaterial1 = capsuleRenderer1.material;
        capsuleMaterial1.mainTexture = sourceTexture1;
        sourceRenderer1.enabled = false;
    }
    
}
