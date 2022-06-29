using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject propsParent;

    [SerializeField] Animator scoopAnim;
    //[SerializeField] GameObject iceHolder;
    //[SerializeField] GameObject crusherLid;
    //[SerializeField] GameObject stickZoneObj;

    [SerializeField] GameObject popsicleObj;
    [SerializeField] GameObject popsicleParent;
    [SerializeField] GameObject popsicleColliders;
    [SerializeField] GameObject directionalLight;

    [SerializeField] GameObject stick;

    //[SerializeField] GameObject nextButton;
    //[SerializeField] GameObject eraseButton;
    //[SerializeField] GameObject doneButton;

    [SerializeField] GameObject preparePanel;
    [SerializeField] GameObject iceTubButton;
    [SerializeField] GameObject glassButton;
    [SerializeField] GameObject stickButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject modeButton;
    //[SerializeField] GameObject paintPanel;
    //[SerializeField] GameObject winPanel;
    //[SerializeField] GameObject fadePanel;

    //[SerializeField] GameObject blurBG;

    [SerializeField] Vector3 propPosOffset = new Vector3();

    [SerializeField] Camera mainCam;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //HideNextButton();

        //eraseButton.SetActive(false);
        //doneButton.SetActive(false);

        //blurBG.SetActive(false);
        //winPanel.SetActive(false);

        MoveLightSimple();
    }

    void Update()
    {
        //if(AllBools.Instance.isReadyForPaint == true && AllBools.Instance.isPaintDone == false)
        //{
        //    ShowPaintStuffs();
        //}
        //else
        //{
        //    HidePaintStuffs();
        //}
    }

    public void MoveProps()
    {
        Vector3 targetPos = new Vector3();
        targetPos = propsParent.transform.position + propPosOffset;

        propsParent.transform.DOMove(targetPos, 0.4f).OnComplete(() =>
        {
            //HandController.Instance.StickSwipe();
            //preparePanel.SetActive(true);
        });

        //if(stickZoneObj.activeInHierarchy == false)
        //{
        //    stickZoneObj.SetActive(true);
        //}

        //HideNextButton();

        //propsParent.transform.position += propPosOffset;
    }

    public void AddIce()
    {
        scoopAnim.SetTrigger("move");

        iceTubButton.SetActive(false);
        glassButton.SetActive(false);
        stickButton.SetActive(true);
        preparePanel.SetActive(false);
    }

    public void MoveCameraToCrusher()
    {
        mainCam.transform.DOMove(new Vector3(0, 4.55f, -2.1f), 0.4f);
        mainCam.transform.rotation = Quaternion.Euler(13, 0, 0);
    }

    public void MoveCameraToPopsicle()
    {
        mainCam.transform.DOMove(new Vector3(0, 13.5f, -13.2f), 0.6f);
        mainCam.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void MoveLightSimple()
    {
        directionalLight.transform.rotation = Quaternion.Euler(55, 15, 0);
    }

    public void MoveLightPaint()
    {
        directionalLight.transform.rotation = Quaternion.Euler(70, 60, 0);
    }

    public void ReadyToSculpt()
    {
        popsicleObj.GetComponent<MeshCollider>().enabled = false;
        popsicleColliders.SetActive(true);
        popsicleColliders.transform.parent = popsicleParent.transform;

        popsicleObj.GetComponent<PopsicleController>().enabled = true;

        preparePanel.SetActive(true);
    }

    public void MoveStick()
    {
        stick.transform.DOMove(new Vector3(0, 4.55f, -14f), 0.3f);
        stick.transform.parent = popsicleObj.transform;

        stickButton.SetActive(false);
        preparePanel.SetActive(false);

        nextButton.SetActive(false);
        modeButton.SetActive(true);
    }

    //public void ShowPaintStuffs()
    //{
    //    if (paintPanel.activeInHierarchy == false)
    //    {
    //        paintPanel.SetActive(true);

    //        eraseButton.SetActive(true);
    //        doneButton.SetActive(true);
    //        blurBG.SetActive(true);
    //    }
    //}

    //public void HidePaintStuffs()
    //{
    //    if (paintPanel.activeInHierarchy == true)
    //    {
    //        paintPanel.SetActive(false);

    //        eraseButton.SetActive(false);
    //        doneButton.SetActive(false);
    //    }
    //}

    //public void ShowNextButton()
    //{
    //    if (nextButton.activeInHierarchy == false)
    //    {
    //        nextButton.SetActive(true);
    //    }
    //}

    //public void HideNextButton()
    //{
    //    if (nextButton.activeInHierarchy == true)
    //    {
    //        nextButton.SetActive(false);
    //    }
    //}

    //public void PaintDone()
    //{
    //    AllBools.Instance.isPaintDone = true;

    //    HidePaintStuffs();

    //    if(winPanel.activeInHierarchy == false)
    //    {
    //        winPanel.SetActive(true);
    //    }
    //}

    //public void ErasePaint()
    //{
    //    PaintTarget.ClearAllPaint();
    //}

    //public void FadeScreen()
    //{
    //    if(fadePanel.activeInHierarchy == false)
    //    {
    //        fadePanel.SetActive(true);
    //    }

    //    Image fadeImg = fadePanel.GetComponent<Image>();

    //    fadeImg.DOFade(1.0f, 0.4f).OnComplete(() => {
    //        fadeImg.DOFade(0f, 0.8f).OnComplete(() => {
    //            fadePanel.SetActive(false);
    //        });
    //    });
    //}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
