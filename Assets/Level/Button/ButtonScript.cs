using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public bool allowed;
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
        }
    }
}
