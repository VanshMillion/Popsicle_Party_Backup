using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaintShooter : MonoBehaviour
{
	private Camera mainCam;

	[SerializeField] GameObject bottleObj;
	[SerializeField] GameObject nozzle;
	[SerializeField] GameObject nozzleEnd;
	[SerializeField] LayerMask snowLayer;

	[SerializeField] GameObject paintPrefab;

	[SerializeField] Vector3 offset;
	[SerializeField] Vector3 bottleOffset;

	Vector3 pointerPos = new Vector3();
	Vector3 mainPos = new Vector3();

	void Start()
	{
		bottleObj.gameObject.SetActive(false);

		mainCam = Camera.main;
	}

    private void Update()
	{
		GetPointerPosition();
	}

	void GetPointerPosition()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount > 0)
			{
				//bottleObj.SetActive(true);
				if (bottleObj.activeInHierarchy == false)
				{
					bottleObj.SetActive(true);
				}

				Touch touch = Input.GetTouch(0);

				pointerPos = touch.position;

				//pointerPos.x = (pointerPos.x - width) / width;
				//pointerPos.y = (pointerPos.y - height) / height;

				Ray ray = mainCam.ScreenPointToRay(pointerPos);
				if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, snowLayer))
				{
					mainPos = hit.point + offset;
					mainPos.z = offset.z;

					Shoot();
				}

				//mainPos = new Vector3(pointerPos.x, pointerPos.y, transform.position.z - Camera.main.transform.position.z);
				//mainPos = mainCam.ScreenToWorldPoint(mainPos);
			}
            else
            {
				//bottleObj.SetActive(false);
			}
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				//bottleObj.SetActive(true);
				if (bottleObj.activeInHierarchy == false)
				{
					bottleObj.SetActive(true);
				}

				pointerPos = Input.mousePosition;

				//pointerPos.x = (pointerPos.x - width) / width;
				//pointerPos.y = (pointerPos.y - height) / height;

				Ray ray = mainCam.ScreenPointToRay(pointerPos);
				if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, snowLayer))
                {
					mainPos = hit.point + offset;
					mainPos.z = offset.z;

					Shoot();
				}

				//mainPos = new Vector3(pointerPos.x, pointerPos.y, pointerPos.z);
				//mainPos = mainCam.ScreenToWorldPoint(mainPos);
			}
			else
            {
				//bottleObj.SetActive(false);
			}
		}

		nozzleEnd.transform.position = mainPos;

		bottleObj.transform.position = new Vector3(pointerPos.x + bottleOffset.x, pointerPos.y + bottleOffset.y);
		//Debug.Log(mainPos);
	}

	void Shoot()
    {
		Instantiate(paintPrefab, nozzle.transform.position, Quaternion.identity);
    }
}
