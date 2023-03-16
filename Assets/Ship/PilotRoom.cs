using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotRoom : MonoBehaviour
{
    [SerializeField] [Range(0.25f, 0.75f)]
    private float spinSpeed;




    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
