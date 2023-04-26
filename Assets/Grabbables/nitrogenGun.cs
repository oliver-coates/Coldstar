using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nitrogenGun : MonoBehaviour
{
    private bool isOn = false;
    [SerializeField] private GameObject nozzle;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask freezable;
    [SerializeField] private GameObject coldSpray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(nozzle.transform.position, Vector3.forward, out hit, maxDistance, freezable))
            {
                
                hit.transform.gameObject.GetComponent<freezableScript>().Freeze();
                
            }
        }

    }

    public void triggerPulled()
    {
        coldSpray.SetActive(true);
        isOn = true;
    }

    public void triggerReleased()
    {
        coldSpray.SetActive(false);
        isOn = false;
    }
}
