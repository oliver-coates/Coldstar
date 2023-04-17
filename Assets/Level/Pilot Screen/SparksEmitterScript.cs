using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksEmitterScript : MonoBehaviour
{
    public ParticleSystem particleSystem;

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private float waitTimeLowerBound;
    [SerializeField]
    private float waitTimeUpperBound;
   

    public void StartEmitting()
    {
        StartCoroutine(Emit());
    }

    private IEnumerator Emit()
    {
        particleSystem.Play();

        waitTime = Random.Range(waitTimeLowerBound, waitTimeUpperBound);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(Emit());
    }
}
