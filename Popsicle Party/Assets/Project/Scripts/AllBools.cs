using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBools : MonoBehaviour
{
    public static AllBools Instance;

    [HideInInspector] public bool isIceReady;
    [HideInInspector] public bool isLidLocked;
    [HideInInspector] public bool isHandleMoving;
    [HideInInspector] public bool isCupLocked;
    [HideInInspector] public bool isPopsicleLocked;
    [HideInInspector] public bool isReadyForPaint;
    [HideInInspector] public bool isPaintDone;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        isIceReady = false;
        isLidLocked = false;
        isHandleMoving = false;
        isCupLocked = true;
        isPopsicleLocked = true;
        isReadyForPaint = false;
        isPaintDone = false;
    }
}
