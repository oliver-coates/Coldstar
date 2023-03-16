using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    [SerializeField] [Range(0.25f, 0.75f)]
    private float spinSpeed;

    public float timeElapsed;

    [SerializeField]
    private float maxTime;
    [SerializeField]
    private float maxTimePlanetDelay; // Adder to maxTime when calculating planetLerpAmount, adjust this to ensure the planet doesn't actually hit the camera etc...

    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);


        float lerpAmount = (4f + ( Mathf.Pow((timeElapsed / (maxTime + maxTimePlanetDelay) ),2) - 4f)); // Formulae for planet distance:

        transform.position = Vector3.Lerp(startPos, endPos, lerpAmount);

        //Debug.Log(Mathf.Round( (timeElapsed / maxTime) * 100f) + "%");
    }
}
