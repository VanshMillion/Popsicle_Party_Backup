using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveOnClick : MonoBehaviour
{
    public enum ObjectType
    {
        none,
        crusherLid,
        snowBowl,
        popsicle
    }

    [SerializeField] ObjectType obj;

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 targetPos;

    [SerializeField] GameObject popsicleParent;

    bool isOnTarget;

    void Start()
    {
        transform.position = startPos;

        isOnTarget = false;
    }

    void OnMouseDown()
    {
        if (obj == ObjectType.crusherLid && AllBools.Instance.isIceReady == true && AllBools.Instance.isLidLocked == false)
        {
            if (isOnTarget == false)
            {
                HandController.Instance.HideHandPanel();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;
                    AllBools.Instance.isLidLocked = true;
                    HandController.Instance.HandleClick();
                });
            }
            //else
            //{
            //    transform.DOMove(startPos, 0.4f).OnComplete(() => {
            //        isOnTarget = false;
            //        AllBools.Instance.isLidLocked = false;
            //    });
            //}
        }
        
        if(obj == ObjectType.snowBowl && AllBools.Instance.isCupLocked == false)
        {
            if (isOnTarget == false)
            {
                HandController.Instance.HideHandPanel();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;
                    AllBools.Instance.isCupLocked = true;
                    GameManager.Instance.ShowNextButton();
                });
            }
            //else
            //{
            //    transform.DOMove(startPos, 0.4f).OnComplete(() => {
            //        isOnTarget = false;
            //    });
            //}
        }

        if (obj == ObjectType.popsicle && AllBools.Instance.isPopsicleLocked == false)
        {
            if (isOnTarget == false)
            {
                HandController.Instance.HideHandPanel();
                GameManager.Instance.FadeScreen();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;
                    //AllBools.Instance.isPopsicleLocked = true;
                    //GameManager.Instance.ShowNextButton();
                    AllBools.Instance.isReadyForPaint  = true;
                });

                transform.parent = popsicleParent.transform;

                //transform.DORotate(new Vector3(-240, 0, 0), 0.4f);
                transform.rotation = Quaternion.Euler(-240, 0, 0);
            }
            //else
            //{
            //    transform.DOMove(startPos, 0.4f).OnComplete(() => {
            //        isOnTarget = false;
            //    });
            //}
        }
    }
}
