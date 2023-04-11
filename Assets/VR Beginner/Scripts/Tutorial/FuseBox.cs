using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public ParticleSystem[] SparkleFuseVFX;
    public ParticleSystem[] SwitchedOnVFX;
    public ParticleSystem[] SwitchedOffVFX;

    public EmissionChange emissionChange;

    bool m_FusePresent = false;
    bool m_SwitchOn = false;

    public void Switched(int step)
    {
        m_SwitchOn = step == 0 ? false : true;

        if (!m_FusePresent)
            return;

        if (step == 0)
        {
            foreach (var s in SwitchedOffVFX)
            {
                s.Play();
            }
            emissionChange.FlipPower(false);
        }
        else
        {
            foreach (var s in SwitchedOnVFX)
            {
                s.Play();
            }
            emissionChange.FlipPower(true);
        }
    }
    
    public void FuseSocketed(bool socketed)
    {
        m_FusePresent = socketed;

        if (m_FusePresent)
        {
            foreach (var s in SparkleFuseVFX)
            {
                s.Play();
            }

            if(m_SwitchOn)
                emissionChange.FlipPower(true);
        }
        else
        {
            emissionChange.FlipPower(false);
        }
    }
}
