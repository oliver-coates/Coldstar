using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMaster : MonoBehaviour
{
    [SerializeField] private float boltCount = 4;
    public Rigidbody rb;
    public float pushForce;
    void Update()
    {
        if (boltCount <= 0){
            Open();
        }
    }

    public void removeBolt(){
        boltCount -= 1;
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
