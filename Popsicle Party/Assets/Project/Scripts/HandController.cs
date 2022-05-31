using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandController : MonoBehaviour
{
    public static HandController Instance;

    [SerializeField] Transform bowlPos;
    [SerializeField] Transform iceDropPos;
    [SerializeField] Transform lidPos;
    [SerializeField] Transform handlePos;
    [SerializeField] Transform cupPos;
    [SerializeField] Transform stickPos;
    [SerializeField] Transform popsiclePos;

    [SerializeField] GameObject handPanel;

    [HideInInspector] public Animator handAnim;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        ShowHandPanel();

        handAnim = GetComponent<Animator>();

        IceSwipe();
    }

    //IEnumerator SlideHand()
    //{
    //    transform.position = Vector3.Slerp(transform.position, iceDropPos.position, 1.2f);
    //    yield return new WaitForSeconds(1.2f);
    //    transform.position = bowlPos.position;
    //    yield return new WaitForSeconds(0.2f);
    //    StartCoroutine(SlideHand());
    //}

    void SlideIce()
    {
        if (transform.position != bowlPos.position)
        {
            transform.position = bowlPos.position;
        }

        //StartCoroutine(SlideHand());

        transform.DOMove(iceDropPos.position, 1.2f).OnComplete(() =>
        {
            if (AllBools.Instance.isIceReady == false)
            {
                SlideIce();
            }
            else
            {
                LidClick();
            }
        });
    }

    void SlideStick()
    {
        transform.position = bowlPos.position;

        //StartCoroutine(SlideHand());

        transform.DOMove(stickPos.position, 1.2f).OnComplete(() =>
        {
            if (AllBools.Instance.isPopsicleLocked == true)
            {
                SlideStick();
            }
            else
            {
                PopsicleClick();
            }
        });
    }

    public void ShowHandPanel()
    {
        if(handPanel.activeInHierarchy == false)
        {
            handPanel.SetActive(true);
        }
    }

    public void HideHandPanel()
    {
        if(handPanel.activeInHierarchy == true)
        {
            handPanel.SetActive(false);
        }
    }

    public void IceSwipe()
    {
        transform.position = bowlPos.position;
        handAnim.SetBool("isBlinking", false);

        ShowHandPanel();

        SlideIce();
    }

    public void LidClick()
    {
        ShowHandPanel();

        transform.position = lidPos.position;
        handAnim.SetBool("isBlinking", true);
    }

    public void HandleClick()
    {
        ShowHandPanel();

        transform.position = handlePos.position;
        handAnim.SetBool("isBlinking", true);
    }

    public void CupClick()
    {
        ShowHandPanel();

        transform.position = cupPos.position;
        handAnim.SetBool("isBlinking", true);
    }

    public void StickSwipe()
    {
        transform.position = bowlPos.position;
        handAnim.SetBool("isBlinking", false);

        ShowHandPanel();

        SlideStick();
    }

    public void PopsicleClick()
    {
        ShowHandPanel();

        transform.position = popsiclePos.position;
        handAnim.SetBool("isBlinking", true);
    }
}
