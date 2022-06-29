using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavourManager : MonoBehaviour
{
    [SerializeField] GameObject paintParticlePref;

    [SerializeField] Color color;
    [SerializeField] Material paintParticleMat;
    //[SerializeField] Renderer snowRenderer;

    //[Range(0, 6)]
    //[SerializeField] int channel;

    [SerializeField] PaintIn3D.P3dPaintSphere brush;

    public void ChangeColor()
    {
        paintParticleMat.color = color;
        brush.Color = color;
    }
}
