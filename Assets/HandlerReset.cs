using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerReset : MonoBehaviour
{
    [SerializeField]
    Transform m_target;
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void ResetGrabHandler()
    {
        transform.position = m_target.position;
        transform.rotation = m_target.rotation;
        m_Rigidbody.MovePosition(m_target.transform.position);
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
    }
}
