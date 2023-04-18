using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltageChipScript : MonoBehaviour
{
    public Rigidbody rb;

    public Animator handL;

    bool ignoreFirst = true;

    public void Grabbed()
    {
        if (ignoreFirst)
        {
            ignoreFirst = false;
            return;
        }
        rb.isKinematic = true;
        handL.SetBool("grippingChip", true);
    }

    public void Dropped()
    {
        rb.isKinematic = false;
        handL.SetBool("grippingChip", false);
    }
}
