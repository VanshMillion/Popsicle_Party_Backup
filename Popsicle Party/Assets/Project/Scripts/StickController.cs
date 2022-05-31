using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickController : MonoBehaviour
{
    private GameObject snowObj;

    [SerializeField] Vector3 targetPos = new Vector3();

    [HideInInspector] public bool isFixed = false;

    void Start()
    {
        snowObj = GameObject.FindGameObjectWithTag("Snow");
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if(tag == "StickZone")
        {
            MoveStick();
            other.gameObject.SetActive(false);
            AllBools.Instance.isPopsicleLocked = false;
        }
    }

    void MoveStick()
    {
        if (transform.gameObject.GetComponent<DragDrop>().isSelected == true)
        {
            transform.gameObject.GetComponent<DragDrop>().isSelected = false;

            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;

            transform.DOMove(targetPos, 0.3f).OnComplete(() => {
                isFixed = true;
            });
            transform.rotation = Quaternion.Euler(90f, 0, 0);
            transform.parent = snowObj.transform;

            HandController.Instance.PopsicleClick();
        }
    }
}
