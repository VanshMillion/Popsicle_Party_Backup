using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private PopsicleController popsicle;
    [SerializeField] Vector3 moveLimits;

    float hor;
    float ver;

    Vector3 movement;
    Vector3 targetPos;

    [SerializeField] private ParticleSystem snowFx;

    private ParticleSystem.EmissionModule snowFxEmission;

    //private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;

    private void Start()
    {
        //knifeRb = GetComponent<Rigidbody>();

        snowFxEmission = snowFx.emission;
        snowFxEmission.enabled = false;
    }

    private void Update()
    {
        //isMoving = Input.GetMouseButton(0) || Input.touchCount > 0;
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
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

            targetPos = new Vector3((Mathf.Clamp(movement.x, -moveLimits.x + 3, moveLimits.x + 1)), movement.y, (Mathf.Clamp(movement.z, -moveLimits.z + 1, moveLimits.z + 1))); //Don't let hole move beyond moveLimits
        }
            //movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            transform.position = targetPos;
    }

    private void OnCollisionExit(Collision collision)
    {
        snowFxEmission.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        Coll coll = collision.collider.GetComponent<Coll>();
        if (coll != null)
        {
            // hit Collider:
            snowFxEmission.enabled = true;
            snowFx.transform.position = collision.contacts[0].point;

            coll.HitCollider(hitDamage);
            popsicle.Hit(coll.index, hitDamage);
        }
    }
}
