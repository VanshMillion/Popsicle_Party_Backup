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

    [SerializeField] GameObject lidParent;
    [SerializeField] GameObject popsicleParent;

    bool isOnTarget;

    void Start()
    {
        transform.position = startPos;

        isOnTarget = false;
    }

    //private void Update()
    //{
    //    if (obj == ObjectType.popsicle /*&& AllBools.Instance.isPopsicleLocked == false*/)
    //    {
    //        transform.DOMove(targetPos, 0.4f);
    //    }
    //}


    void OnMouseDown()
    {
        if (obj == ObjectType.crusherLid /*&& AllBools.Instance.isIceReady == true && AllBools.Instance.isLidLocked == false*/)
        {
            if (isOnTarget == false)
            {
                //HandController.Instance.HideHandPanel();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;

                    transform.parent = lidParent.transform;
                    //AllBools.Instance.isLidLocked = true;
                    //HandController.Instance.HandleClick();
                    //HandController.Instance.HandleClick();
                    GameManager.Instance.ShowRotator();
                });

                //GameManager.Instance.HideNextButton();
                HandController.Instance.HideHandPanel();
                GameManager.Instance.MoveCameraToCrusher();
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
                //HandController.Instance.HideHandPanel();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;
                    AllBools.Instance.isCupLocked = true;
                    //GameManager.Instance.ShowNextButton();
                });
            }
            //else
            //{
            //    transform.DOMove(startPos, 0.4f).OnComplete(() => {
            //        isOnTarget = false;
            //    });
            //}
        }

        if (obj == ObjectType.popsicle /*&& AllBools.Instance.isPopsicleLocked == false*/)
        {
            if (isOnTarget == false)
            {
                //HandController.Instance.HideHandPanel();
                //GameManager.Instance.FadeScreen();

                transform.DOMove(targetPos, 0.4f).OnComplete(() => {
                    isOnTarget = true;
                    AllBools.Instance.isPopsicleLocked = false;

                    GameManager.Instance.ReadyToSculpt();
                    //GameManager.Instance.ShowNextButton();
                    //AllBools.Instance.isReadyForPaint  = true;
                });

                transform.parent = popsicleParent.transform;
                //p.opsicleParent.GetComponent<Popsicle>().enabled = true;

                //transform.DORotate(new Vector3(-240, 0, 0), 0.4f);
                transform.localScale = new Vector3(1, 1, 1);
                transform.rotation = Quaternion.Euler(90, 0, 0);
                //ModeChanger.Instance.ChangeMode();

                HandController.Instance.HideHandPanel();

                GameManager.Instance.MoveCameraToPopsicle();
                GameManager.Instance.MoveLightPaint();
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
