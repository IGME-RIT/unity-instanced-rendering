using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRendering : MonoBehaviour
{
    // instance rendering only allows for 0 to 1023 objects to be rendered in one call, so we'll clamp the editor to those values
    [Range(0,1023)]
    public int instanceCount = 1000;
    
    public Mesh instanceMesh;

    // any material will work for the way we will be doing instance rendering as long as it has "Enable GPU Instancing" checked
    // this is not always the case with instance rendering, and we will cover this in the next demo
    public Material instanceMaterial;

    Matrix4x4[] instanceTransforms;
    
    void Start()
    {
        instanceTransforms = new Matrix4x4[instanceCount];
        GenerateTransforms();
    }
    
    void Update()
    {
        Graphics.DrawMeshInstanced(instanceMesh, 0, instanceMaterial, instanceTransforms, instanceCount);
    }

    /// <summary>
    /// This method exists to generate an array of transform matricies with random positions rotations and scales
    /// </summary>
    private void GenerateTransforms()
    {
        Vector3 pos = new Vector3();
        Quaternion rot = new Quaternion();
        Vector3 scale = new Vector3();
        for (int i = 0; i < instanceCount; i++)
        {
            pos = Random.insideUnitSphere * 50;
            rot = Random.rotation;
            scale = new Vector3(Random.Range(0,2.0f), Random.Range(0, 2.0f), Random.Range(0, 2.0f));
            instanceTransforms[i] = Matrix4x4.TRS(pos, rot, scale);
        }
    }
}
