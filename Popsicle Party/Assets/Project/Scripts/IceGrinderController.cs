using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGrinderController : MonoBehaviour
{
    public static IceGrinderController Instance;

    [SerializeField] ParticleSystem snowParticle;
    [SerializeField] GameObject snowObj;

    [SerializeField] MoveOnClick moveOnClick;

    private Vector3 maxSize = new Vector3(0.9f, 0.9f, 0.9f);

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        StopIncreasingSize();
    }

    public void GrinderRunning()
    {
        if(snowParticle.isPlaying == false)
        {
            snowParticle.Play();
        }
    }

    public void GrinderStop()
    {
        if(snowParticle.isPlaying == true)
        {
            snowParticle.Stop();
        }
    }

    public void IncreaseSnowSize()
    {
        if(snowObj.transform.localScale.x < maxSize.x)
        {
            snowObj.transform.localScale += new Vector3(0.0003f, 0, 0);
        }

        if (snowObj.transform.localScale.y < maxSize.y)
        {
            snowObj.transform.localScale += new Vector3(0, 0.0003f, 0);
        }

        if (snowObj.transform.localScale.z < maxSize.z)
        {
            snowObj.transform.localScale += new Vector3(0, 0, 0.001f);
        }
    }
    
    void StopIncreasingSize()
    {
        if(snowObj.transform.localScale.z > 0.9f && AllBools.Instance.isCupLocked == true)
        {
            if(AllBools.Instance.isHandleMoving == true)
            {
                HandController.Instance.CupClick();
            }

            AllBools.Instance.isHandleMoving = false;
            AllBools.Instance.isCupLocked = false;
        }
    }
}
