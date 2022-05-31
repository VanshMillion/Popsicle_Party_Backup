using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public enum ObjectType
    {
        none,
        ice,
        stick
    }

    [SerializeField] ObjectType obj;

    private Vector3 mOffset;

    private float mZCoord;

    [HideInInspector] public bool isSelected = false;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        gameObject.GetComponent<DragDrop>().isSelected = true;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if(isSelected == true)
        {
            if (obj == ObjectType.ice) 
            {
                transform.position = GetMouseAsWorldPoint() + mOffset;
                HandController.Instance.HideHandPanel();
                HandController.Instance.LidClick();
            }

            if(obj == ObjectType.stick && gameObject.GetComponent<StickController>().isFixed == false)
            {
                transform.position = GetMouseAsWorldPoint() + mOffset;
            }
        }
    }

    void OnMouseUp()
    {
        if(isSelected == true)
        {
            isSelected = false;
        }
    }
}