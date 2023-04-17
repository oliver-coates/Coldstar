using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltageChipScript : MonoBehaviour
{
    public Rigidbody rb;

    public Animator handL;

    public void Grabbed()
    {
        rb.isKinematic = true;
        handL.SetBool("grippingChip", true);
    }

    public void Dropped()
    {
        rb.isKinematic = false;
        handL.SetBool("grippingChip", false);
    }
}
