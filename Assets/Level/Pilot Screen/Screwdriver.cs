using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    // Screwdriver script attached to the box collider of the tip of the screwdriver
    public Rigidbody rb;

    public Animator handL;

    public void Grabbed()
    {
        rb.isKinematic = true;
        handL.SetBool("gripping", true);
    }

    public void Dropped()
    {
        rb.isKinematic = false;
        handL.SetBool("gripping", false);
    }
}
