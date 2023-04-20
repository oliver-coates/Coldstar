using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReaderScript : MonoBehaviour
{

    public Light readerLight;
    public Color lockedColor;
    public Color openColor;
    public AudioClip openSound;
    public AudioSource audioSource;
    private bool locked = true;
    public LockBoxScript lockBox;

    void Start()
    {
        readerLight.color = lockedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Keycard") && locked)
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        locked = false;

        readerLight.color = openColor;
        audioSource.PlayOneShot(openSound);
        lockBox.Open();
    }   
}
