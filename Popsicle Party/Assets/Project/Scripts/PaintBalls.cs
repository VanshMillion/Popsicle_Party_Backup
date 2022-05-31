using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBalls : MonoBehaviour
{
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 60 * Time.deltaTime, ForceMode.Impulse);

        Destroy(gameObject, 0.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Snow")
        {
            Destroy(gameObject, .01f);
        }
    }
}
