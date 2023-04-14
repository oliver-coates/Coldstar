using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainencePanelScript : MonoBehaviour
{
    public Rigidbody panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScrewdriverPoint"))
        {
            // Eject maintainence hatch

            panel.isKinematic = false;
            panel.AddForce(panel.transform.forward * 0.75f, ForceMode.Impulse);


            Destroy(gameObject); // Destroy myself to finish
        }
    }
}
