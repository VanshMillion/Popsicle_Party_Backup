using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavourManager : MonoBehaviour
{
    [SerializeField] GameObject paintParticlePref;

    [SerializeField] Color color;
    [SerializeField] Material paintParticleMat;
    [SerializeField] MeshRenderer paintBottleMesh;
    [SerializeField] Material bottleColorMat;

    [SerializeField] Color startColor;
    //[SerializeField] Renderer snowRenderer;

    //[Range(0, 6)]
    //[SerializeField] int channel;

    [SerializeField] PaintIn3D.P3dPaintSphere brush;

    void Start()
    {
        brush.Color = startColor;
        paintParticleMat.color = startColor;
    }

    public void ChangeColor()
    {
        paintParticleMat.color = color;
        brush.Color = color;

        paintBottleMesh.material = bottleColorMat;
    }
}
