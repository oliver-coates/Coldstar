using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class freezableScript : MonoBehaviour
{
    bool frozen = false;
    public panelMaster panelScript;
    public AudioSource audioSource;
    public AudioClip breakSound;

    public void Freeze()
    {
        if (frozen)
        {
            return;
        }

        audioSource.PlayOneShot(breakSound);

        frozen = true;
        panelScript.removeBolt();
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        
        Rigidbody rb =  gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        rb.AddForce(transform.up / 3f, ForceMode.Impulse);

    
    }
}
