using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionChange : MonoBehaviour
{
    [SerializeField]
    MeshRenderer m_RoomLightMesh;
    [SerializeField]
    Light m_RoomLightLight;
    Material m_Material;
    bool m_PowerOn = false;
    float m_LastIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<MeshRenderer>().material;
        m_Material.SetColor("_Color", Color.gray);
        m_RoomLightMesh.material.SetColor("_Color", Color.gray);
        m_RoomLightLight.intensity = 1;
    }

    public void DialChanged(DialInteractable dial)
    {
        if(m_PowerOn)
        {
            m_LastIntensity = dial.CurrentAngle / dial.RotationAngleMaximum;
            m_Material.SetColor("_Color", Color.Lerp(Color.gray, Color.white, m_LastIntensity));
            m_RoomLightMesh.material.SetColor("_Color", Color.Lerp(Color.gray, Color.white, m_LastIntensity));
            m_RoomLightLight.intensity = m_LastIntensity * 10;
        }
    }

    public void FlipPower(bool b)
    {
        m_PowerOn = b;
        if(m_PowerOn)
        {
            m_Material.SetColor("_Color", Color.Lerp(Color.gray, Color.white, m_LastIntensity));
            m_RoomLightMesh.material.SetColor("_Color", Color.Lerp(Color.gray, Color.white, m_LastIntensity));
            m_RoomLightLight.intensity = m_LastIntensity * 10;
        }
        else
        {
            m_Material.SetColor("_Color", Color.gray);
            m_RoomLightMesh.material.SetColor("_Color", Color.gray);
            m_RoomLightLight.intensity = 1;
        }
    }
}
