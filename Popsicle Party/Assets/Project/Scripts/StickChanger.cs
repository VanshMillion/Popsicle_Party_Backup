using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickChanger : MonoBehaviour
{
    [SerializeField] MeshRenderer stickMesh;
    [SerializeField] Material stickColorMat;

    public void ChangeStick()
    {
        stickMesh.material = stickColorMat;

        GameManager.Instance.MoveStick();
        ModeChanger.Instance.ChangeMode();
        //GameManager.Instance.ShowNextButton();
    }
}
