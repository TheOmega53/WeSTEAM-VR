using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportToObject3 : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject sourceObject3;
    public GameObject cubeObject3;
    public GameObject cylinderObject3;
    public GameObject sphereObject3;
    public GameObject capsuleObject3;


    void Start()
    {
        Renderer cubeRenderer3 = cubeObject3.GetComponent<Renderer>();
        cubeRenderer3.enabled = false;
        
        Renderer cylinderRenderer3 = cylinderObject3.GetComponent<Renderer>();
        cylinderRenderer3.enabled = false;
        
        Renderer sphereRenderer3 = sphereObject3.GetComponent<Renderer>();
        sphereRenderer3.enabled = false;
        
        Renderer capsuleRenderer3 = capsuleObject3.GetComponent<Renderer>();
        capsuleRenderer3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ExportAndAssignTexture();
    }
    
    public void ExportAndAssignTextureCube3()
    {
        Renderer sourceRenderer3 = sourceObject3.GetComponent<Renderer>();
        Renderer cubeRenderer3 = cubeObject3.GetComponent<Renderer>();
        if (sourceRenderer3 != null && cubeRenderer3 != null)
        {
            Material sourceMaterial3 = sourceRenderer3.sharedMaterial;
            Material copiedMaterial3 =new Material(sourceMaterial3);
            copiedMaterial3.CopyPropertiesFromMaterial(sourceMaterial3);
            cubeRenderer3.enabled = true;
            cubeRenderer3.material = copiedMaterial3;
        }
        
        sourceRenderer3.enabled = false;
        Debug.Log("vaghn miai inja");
    }
    public void ExportAndAssignTextureCylinder3()
    { 
        Renderer sourceRenderer3 = sourceObject3.GetComponent<Renderer>();
        Material sourceMaterial3 = sourceRenderer3.material;
        Texture sourceTexture3 = sourceMaterial3.mainTexture;
        Renderer cylinderRenderer3 = cylinderObject3.GetComponent<Renderer>();
        cylinderRenderer3.enabled = true;
        Material cylinderMaterial3 = cylinderRenderer3.material;
        cylinderMaterial3.mainTexture = sourceTexture3;
        sourceRenderer3.enabled = false;
    }
    public void ExportAndAssignTextureSphere3()
    { 
        Renderer sourceRenderer3 = sourceObject3.GetComponent<Renderer>();
        Material sourceMaterial3 = sourceRenderer3.material;
        Texture sourceTexture3 = sourceMaterial3.mainTexture;
        Renderer sphereRenderer3 = sphereObject3.GetComponent<Renderer>();
        sphereRenderer3.enabled = true;
        Material sphereMaterial3 = sphereRenderer3.material;
        sphereMaterial3.mainTexture = sourceTexture3;
        sourceRenderer3.enabled = false;
    }
    public void ExportAndAssignTextureCapsule3()
    { 
        Renderer sourceRenderer3 = sourceObject3.GetComponent<Renderer>();
        Material sourceMaterial3 = sourceRenderer3.material;
        Texture sourceTexture3 = sourceMaterial3.mainTexture;
        Renderer capsuleRenderer3 = capsuleObject3.GetComponent<Renderer>();
        capsuleRenderer3.enabled = true;
        Material capsuleMaterial3 = capsuleRenderer3.material;
        capsuleMaterial3.mainTexture = sourceTexture3;
        sourceRenderer3.enabled = false;
    }
    
}
