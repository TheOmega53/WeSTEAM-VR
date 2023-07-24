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
        //Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        //Material sourceMaterial = sourceRenderer.material;
        //Texture sourceTexture = sourceMaterial.mainTexture;
        //Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();
        cubeObject.GetComponent<Renderer>().enabled = true;
        //Material cubeMaterial = cubeRenderer.material;
        //cubeMaterial.mainTexture = sourceTexture;
        
        cubeObject.GetComponent<Renderer>().material.mainTexture = sourceObject.GetComponent<Renderer>().material.mainTexture;
    }
    public void ExportAndAssignTextureCylinder()
    { 
        //Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        //Material sourceMaterial = sourceRenderer.material;
        //Texture sourceTexture = sourceMaterial.mainTexture;
        //Renderer cylinderRenderer = cylinderObject.GetComponent<Renderer>();
        cylinderObject.GetComponent<Renderer>().enabled = true;
        //Material cylinderMaterial = cylinderRenderer.material;
        //cylinderMaterial.mainTexture = sourceTexture;

        cylinderObject.GetComponent<Renderer>().material.mainTexture = sourceObject.GetComponent<Renderer>().material.mainTexture;
    }
    public void ExportAndAssignTextureSphere()
    { 
        //Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        //Material sourceMaterial = sourceRenderer.material;
        //Texture sourceTexture = sourceMaterial.mainTexture;
        //Renderer sphereRenderer = sphereObject.GetComponent<Renderer>();
        sphereObject.GetComponent<Renderer>().enabled = true;
        //Material sphereMaterial = sphereRenderer.material;
        //sphereMaterial.mainTexture = sourceTexture;

        sphereObject.GetComponent<Renderer>().material.mainTexture = sourceObject.GetComponent<Renderer>().material.mainTexture;

    }
    public void ExportAndAssignTextureCapsule()
    {
        //Renderer sourceRenderer = sourceObject.GetComponent<Renderer>();
        //Material sourceMaterial = sourceRenderer.material;
        //Texture sourceTexture = sourceMaterial.mainTexture;
        //Renderer capsuleRenderer = capsuleObject.GetComponent<Renderer>();
        //capsuleRenderer.enabled = true;
        capsuleObject.GetComponent<Renderer>().enabled = true;
        //Material capsuleMaterial = capsuleRenderer.material;
        //capsuleMaterial.mainTexture = sourceTexture;
        capsuleObject.GetComponent<Renderer>().material.mainTexture = sourceObject.GetComponent<Renderer>().material.mainTexture;
    }

}
