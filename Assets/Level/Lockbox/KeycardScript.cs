using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardScript : MonoBehaviour
{
    public Animator leftHandAnim;

    public void Gripped()
    {
        leftHandAnim.SetBool("grippingKeycard", true);
    }

    public void UnGripped()
    {
        leftHandAnim.SetBool("grippingKeycard", false);
    }
}
