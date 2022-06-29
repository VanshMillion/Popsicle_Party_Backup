using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] GameObject paintObj;
    [SerializeField] GameObject shapeObj;
    [SerializeField] GameObject outlineObj;

    [SerializeField] GameObject paintPanel;

    [SerializeField] PopsicleController popsicle;

    bool canPaint;

    void Start()
    {
        canPaint = true;

        ChangeMode();
    }

    public void ChangeMode()
    {
        canPaint = !canPaint;

        if (canPaint == true)
        {
            paintPanel.SetActive(true);
            paintObj.SetActive(true);
            shapeObj.SetActive(false);
            //outlineObj.SetActive(false);

            popsicle.rotationDuration = 0.2f;
            //popsicleMeshCol.enabled = true;
            //colliderParent.SetActive(false);
        }
        else
        {
            paintPanel.SetActive(false);
            paintObj.SetActive(false);
            shapeObj.SetActive(true);
            //outlineObj.SetActive(true);

            popsicle.rotationDuration = 0.8f;
            //popsicleMeshCol.enabled = false;
            //colliderParent.SetActive(true);
        }
    }
}
