using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAlphaByProximityToObject : MonoBehaviour
{
    // Description:
    // Changes the Color's alpha value of a text mesh pro based upon proximity to hand.
    // 

    [SerializeField]
    private TextMeshPro textMeshPro;
    [SerializeField]
    private Transform[] handTransforms;

    // These values are all assigned in start as I don't want people fucking with them in-editor
    private float distanceCutoff;
    

    // Start is called before the first frame update
    void Start()
    {
        distanceCutoff = 0.5f;
    }

    // Called in FixedUpdate to slightly reduce operation cost - This is non-frame-critical.
    void FixedUpdate()
    {
        // Find the closest hand
        float handDistance = 0f;

        float lHandDistance = Vector3.Distance(transform.position, handTransforms[0].position);
        float rHandDistance = Vector3.Distance(transform.position, handTransforms[1].position);

        if (lHandDistance < rHandDistance)
        {
            handDistance = lHandDistance;
        }
        else
        {
            handDistance = rHandDistance;
        }

        float alpha = 0f;

        // Check if distance is within cutoff
        if (handDistance < distanceCutoff)
        {
            alpha = distanceCutoff - handDistance;
        }

        textMeshPro.color = new Color(1f, 1f, 1f, alpha);
    }
}
