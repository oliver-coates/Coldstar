using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxScript : MonoBehaviour
{
    public float pushForce;

    public bool debug;

    public Rigidbody rb;

    private void Update() {
        if (debug)
        {
            debug = !debug;
            Open();
        }
    }

    public void Open()
    {
        rb.isKinematic = false;
        rb.AddForce(rb.gameObject.transform.forward * pushForce, ForceMode.Impulse);
        rb.AddTorque(rb.transform.forward * 0.1f, ForceMode.Impulse);
        rb.AddTorque(rb.transform.right * 0.05f, ForceMode.Impulse);
        rb.AddTorque(rb.transform.up * -0.08f, ForceMode.Impulse);
    }
}
