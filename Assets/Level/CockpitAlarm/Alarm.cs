using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alarm : MonoBehaviour
{
    [Header("Audio:")]
    public bool audioPlayer;
    public AudioSource audioSource;
    public AudioClip alarmSound;


    [Header("Light:")]
    public Light pointLight;

    public Color colorL;
    public Color colorR;
    public float lerpSpeed;
    private float lerpAmount;

    public GameObject lightObject;
    public Material lightMat;

    // Start is called before the first frame update
    void Start()
    {
        if (audioPlayer)
        {
            audioSource.PlayOneShot(alarmSound);
        }

        lerpAmount = Random.Range(0f, 1f);
        
        lightObject.GetComponent<MeshRenderer>().material = new Material(lightMat);
        
    }

    // Update is called once per frame
    void Update()
    {
        lerpAmount += Time.deltaTime * lerpSpeed;

        if (lerpAmount > 2) { lerpAmount -= 2; }

        Color newColor = new Color();

        if (lerpAmount < 1)
        {
            newColor = Color.Lerp(colorL, colorR, lerpAmount);
            
        }
        else
        {
            newColor = Color.Lerp(colorL, colorR, 2-lerpAmount);
        }
        
        pointLight.color = newColor;
        lightMat.color = newColor; 
        lightMat.SetColor("_EmissionColor", newColor);
    }
}
