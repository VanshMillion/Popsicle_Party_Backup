using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    public static ModeChanger Instance;

    [SerializeField] GameObject paintObj;
    [SerializeField] GameObject shapeObj;
    [SerializeField] GameObject outlineObj;
    [SerializeField] GameObject modeButton;
    [SerializeField] GameObject doneButton;

    [SerializeField] GameObject paintPanel;

    [SerializeField] PopsicleController popsicle;

    bool canPaint;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        canPaint = false;
        //canPaint = true;

        //ChangeMode();

        paintObj.SetActive(false);
        shapeObj.SetActive(false);
    }

    public void ChangeMode()
    {
        if (canPaint == true)
        {
            paintPanel.SetActive(true);
            paintObj.SetActive(true);
            shapeObj.SetActive(false);
            //outlineObj.SetActive(false);

            popsicle.rotationDuration = 0.2f;
            //popsicleMeshCol.enabled = true;
            //colliderParent.SetActive(false);

            modeButton.SetActive(false);
            doneButton.SetActive(true);
        }
        else
        {
            paintPanel.SetActive(false);
            paintObj.SetActive(false);
            shapeObj.SetActive(true);
            //outlineObj.SetActive(true);

            popsicle.rotationDuration = 0.6f;
            //popsicleMeshCol.enabled = false;
            //colliderParent.SetActive(true);
        }

        canPaint = !canPaint;
    }
}
