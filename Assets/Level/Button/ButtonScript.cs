using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public Light buttonLight;
    public float flickerTime;
    private bool flickering;

    public AudioClip buttonBeep;
    public AudioSource audioSource;

    [SerializeField]
    private bool allowed;
    public bool pressed;
    public UnityEvent buttonPressedEvent;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !pressed && allowed)
        {
            pressed = true;
            buttonPressedEvent.Invoke();
            animator.SetTrigger("pressed");
            EndFlicker();
        }
    }

    public bool isAllowed()
    {
        return allowed;
    }

    public void AllowButton()
    {
        allowed = true;
        StartFlicker();
    }

    private void StartFlicker()
    {
        flickering = true;
        StartCoroutine(LightFlicker());
    }

    private void EndFlicker()
    {
        flickering = false;
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(flickerTime);
        buttonLight.enabled = true;
        audioSource.PlayOneShot(buttonBeep);
        yield return new WaitForSeconds(flickerTime);
        buttonLight.enabled = false;

        if (flickering)
        {
            StartCoroutine(LightFlicker());
        }
    }
}
