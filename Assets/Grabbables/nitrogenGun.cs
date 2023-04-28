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

    private AudioSource audio;
    private ParticleSystem coldSprayParticleSystem;


    void Start()
    {
        coldSprayParticleSystem = coldSpray.GetComponent<ParticleSystem>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (isOn == true)
        {
            coldSprayParticleSystem.Emit(1);

            

            RaycastHit hit;
            if (Physics.Raycast(nozzle.transform.position, nozzle.transform.forward, out hit, maxDistance))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Bolt"))
                {
                    Debug.DrawLine(nozzle.transform.position, nozzle.transform.position + nozzle.transform.forward, Color.red, 0.1f);
                    hit.transform.gameObject.GetComponent<freezableScript>().Freeze();
                }
                
                
            }
            else
            {
                Debug.DrawLine(nozzle.transform.position, nozzle.transform.position + nozzle.transform.forward, Color.green, 0.1f);
            }
        }

    }

    public void pickedUp()
    {
        coldSpray.SetActive(true);
    }

    public void dropped()
    {
        coldSpray.SetActive(false);
    }

    public void triggerPulled()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
        
        isOn = true;
    }

    public void triggerReleased()
    {
        if (audio.isPlaying)
        {
            audio.Pause();
        }
        
        isOn = false;
    }
}
