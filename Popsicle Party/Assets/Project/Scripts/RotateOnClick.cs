using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 0;
    }

    void Update()
    {
        Rotate();
        UpdateSize();
    }

    void Rotate()
    {
        if(AllBools.Instance.isHandleMoving == true)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void UpdateSize()
    {
        if (AllBools.Instance.isHandleMoving == true)
        {
            IceGrinderController.Instance.IncreaseSnowSize();
            IceGrinderController.Instance.GrinderRunning();
        }
        else
        {
            IceGrinderController.Instance.GrinderStop();
        }
    }

    void OnMouseDown()
    {
        if (AllBools.Instance.isHandleMoving == false && AllBools.Instance.isLidLocked == true)
        {
            AllBools.Instance.isHandleMoving = true;
            speed = 80.0f;
            IceGrinderController.Instance.GrinderRunning();
            HandController.Instance.HideHandPanel();
        }
        //else
        //{
        //    AllBools.Instance.isHandleMoving = false;
        //    speed = 0;
        //    IceGrinderController.Instance.GrinderStop();
        //    HandController.Instance.CupClick();
        //}
    }
}
