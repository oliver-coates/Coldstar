using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandCollisionDetector : MonoBehaviour
{
    // Needs to be assigned to an object with a trigger!

    // Checks for a trigger collision with player hands, if so it invokes the event.


    public UnityEvent collideEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            collideEvent.Invoke();
        }
    }
}
