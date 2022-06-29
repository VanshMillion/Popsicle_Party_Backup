using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Transform popsicleTransform;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] public float rotationDuration;

    //private float hor;
    ////private float ver;

    //bool canRotate = false;
    //bool touching = false;

    void Update()
    {
        RotatePopsicle();
    }

    //void OnMouseDown()
    //{
    //    touching = true;
    //}

    //void OnMouseUp()
    //{
    //    touching = false;
    //}

    void RotatePopsicle()
    {
        //if(touching == false)
        //{
        //    if(Application.platform == RuntimePlatform.Android)
        //    {
        //        canRotate = Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved;
        //    }
        //    else
        //    {
        //        canRotate = Input.GetMouseButton(0);
        //    }
        //}

        //hor = Input.GetAxis("Mouse X"); //If player try to move in X-Axis
        //ver = Input.GetAxis("Mouse Y"); //If player try to move in Y-Axis

        if(AllBools.Instance.isPopsicleLocked == false)
        {
            popsicleTransform.Rotate(rotationVector * rotationDuration * Time.deltaTime);

            //transform.Rotate(Vector3.forward * hor * 200 * Time.deltaTime);
            //transform.Rotate(Vector3.right * ver * 100 * Time.deltaTime);
        }
    }

    public void Hit(int keyIndex, float damage)
    {
        float colliderHeight = 2.6f;
        //Skinned mesh renderer key's value is clamped between 0 & 100
        float newWeight = skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) + damage * (100f / colliderHeight);
        skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, newWeight);
    }
}
