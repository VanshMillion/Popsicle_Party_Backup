using UnityEngine;

public class PaintBottle : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] Vector3 moveLimits;

    float hor;
    float ver;

    Vector3 movement;
    Vector3 targetPos;

    //[SerializeField] private ParticleSystem woodFx;

    //private ParticleSystem.EmissionModule woodFxEmission;

    //private Transform bottleRb;
    private Vector3 movementVector;
    private bool isMoving = false;

    private void Start()
    {
        //bottleRb = GetComponent<Rigidbody>();

        //woodFxEmission = woodFx.emission;
    }

    private void Update()
    {
        //isMoving = Input.GetMouseButton(0) || Input.touchCount > 0;
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        if (isMoving)
        {
            hor = Input.GetAxis("Mouse X"); //If player try to move in X-Axis
            ver = Input.GetAxis("Mouse Y"); //If player try to move in Y-Axis

            movement = Vector3.Lerp(transform.position, transform.position + new Vector3(hor, 0f, ver), movementSpeed * Time.deltaTime); //Move hole from current position to Input position with moveSpeed

            targetPos = new Vector3((Mathf.Clamp(movement.x, -moveLimits.x, moveLimits.x)), movement.y, (Mathf.Clamp(movement.z, -moveLimits.z, moveLimits.z))); //Don't let hole move beyond moveLimits
        }
        //movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            transform.position = targetPos;
    }
}
