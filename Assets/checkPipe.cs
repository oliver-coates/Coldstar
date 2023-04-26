using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class checkPipe : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    private IXRSelectInteractable objName;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void checkForGoodPipe()
    {
        objName = socket.GetOldestInteractableSelected();
        if (objName.transform.name == "goodPipe"){
            // win game
        }  
    }
}
