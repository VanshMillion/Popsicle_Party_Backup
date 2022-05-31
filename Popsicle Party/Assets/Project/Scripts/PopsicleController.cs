using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleController : MonoBehaviour
{
    private float hor;
    //private float ver;

    bool canRotate = false;
    bool touching = false;

    void Update()
    {
        RotatePopsicle();
    }

    void OnMouseDown()
    {
        touching = true;
    }

    void OnMouseUp()
    {
        touching = false;
    }

    void RotatePopsicle()
    {
        if(touching == false)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                canRotate = Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved;
            }
            else
            {
                canRotate = Input.GetMouseButton(0);
            }
        }

        hor = Input.GetAxis("Mouse X"); //If player try to move in X-Axis
        //ver = Input.GetAxis("Mouse Y"); //If player try to move in Y-Axis

        if(canRotate == true && AllBools.Instance.isPopsicleLocked == false)
        {
            transform.Rotate(Vector3.forward * hor * 200 * Time.deltaTime);
            //transform.Rotate(Vector3.right * ver * 100 * Time.deltaTime);
        }
    }
}
