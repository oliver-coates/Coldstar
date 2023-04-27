using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class freezableScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze()
    {
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
