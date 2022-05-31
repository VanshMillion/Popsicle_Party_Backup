using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if(tag == "Ice")
        {
            AllBools.Instance.isIceReady = true;
        }
    }
}
