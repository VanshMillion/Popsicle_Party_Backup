using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavourManager : MonoBehaviour
{
    [SerializeField] GameObject paintBallPref;

    [SerializeField] Color color;
    //[SerializeField] Renderer snowRenderer;

    [SerializeField] Image bottleImg;

    [Range(0, 4)]
    [SerializeField] int channel;

    Brush brush;

    void Start()
    {
        brush = paintBallPref.GetComponent<CollisionPainter>().brush;

        brush.splatChannel = 0;
    }

    public void ChangeColor()
    {
        brush.splatChannel = channel;

        bottleImg.color = color;
    }
}
