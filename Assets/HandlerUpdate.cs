using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerUpdate : MonoBehaviour
{
    [SerializeField]
    Transform m_target;
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.MovePosition(m_target.transform.position);
    }
}
