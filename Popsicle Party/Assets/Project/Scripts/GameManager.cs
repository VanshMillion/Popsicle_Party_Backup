using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject propsParent;
    [SerializeField] GameObject stickZoneObj;

    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject eraseButton;
    [SerializeField] GameObject doneButton;

    [SerializeField] GameObject paintPanel;

    [SerializeField] GameObject blurBG;

    [SerializeField] Vector3 propPosOffset = new Vector3();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        HideNextButton();

        eraseButton.SetActive(false);
        doneButton.SetActive(false);
    }

    void Update()
    {
        if(AllBools.Instance.isReadyForPaint == true)
        {
            ShowPaintStuffs();
        }
        else
        {
            HidePaintStuffs();
        }
    }

    public void MoveProps()
    {
        Vector3 targetPos = new Vector3();
        targetPos = propsParent.transform.position + propPosOffset;

        propsParent.transform.DOMove(targetPos, 0.4f).OnComplete(() =>
        {
            HandController.Instance.StickSwipe();
        });

        if(stickZoneObj.activeInHierarchy == false)
        {
            stickZoneObj.SetActive(true);
        }

        HideNextButton();

        //propsParent.transform.position += propPosOffset;
    }

    public void ShowPaintStuffs()
    {
        if (paintPanel.activeInHierarchy == false)
        {
            paintPanel.SetActive(true);

            eraseButton.SetActive(true);
            doneButton.SetActive(true);
            blurBG.SetActive(true);
        }
    }

    public void HidePaintStuffs()
    {
        if (paintPanel.activeInHierarchy == true)
        {
            paintPanel.SetActive(false);

            eraseButton.SetActive(false);
            doneButton.SetActive(false);
            blurBG.SetActive(false);
        }
    }

    public void ShowNextButton()
    {
        if (nextButton.activeInHierarchy == false)
        {
            nextButton.SetActive(true);
        }
    }

    public void HideNextButton()
    {
        if (nextButton.activeInHierarchy == true)
        {
            nextButton.SetActive(false);
        }
    }

    public void ErasePaint()
    {
        PaintTarget.ClearAllPaint();
    }
}
