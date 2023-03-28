using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class HappyGuy : MonoBehaviour
{
    public enum state {fadingIn, fadingOut, cooldown}
    public state currentState;
    public Material myMaterial;

    public Transform[] positions;

    public float fadeSpeed;
    public float fadeOutSpeed;
    public float alphaAmount;

    public float cooldownTime;
    private float cooldownTimer;

    public float scareAlphaThreshold;
    public Transform playerCamera;
    public float scarePointDistance; // THe distance that the scarepoint is located away from the player's face
    public float scarePointThreshold; // The minimum distance that scarepoint has to be to happyguy to scare him.



    void Start()
    {
       EnterCooldown();
        JumpToNewPosition();
    }

    void Update()
    {
        float alpha = 0;

        switch (currentState)
        {
            case state.fadingIn:
                alphaAmount += Time.deltaTime * fadeSpeed;
                alphaAmount = Mathf.Clamp(alphaAmount, 0, 1);
                alpha = alphaAmount;
                if (alpha > scareAlphaThreshold) { CheckScarePoint(); }

                break;

            case state.fadingOut:
                alphaAmount -= Time.deltaTime * fadeOutSpeed;
                alphaAmount = Mathf.Clamp(alphaAmount, 0, 1);
                alpha = alphaAmount;

                if (alpha == 0)
                {
                    currentState = state.cooldown;
                }

                break;

            case state.cooldown:

                cooldownTimer -= Time.deltaTime;

                if (cooldownTimer < 0)
                {
                    JumpToNewPosition();
                    currentState = state.fadingIn;
                }
                break;
        }
        
        // Set alpha
        Color color = myMaterial.color;
        color.a = alpha;
        myMaterial.color = color;
    }

    public void EnterCooldown()
    {
        cooldownTimer = cooldownTime;
        currentState = state.fadingOut;
    }

    public void JumpToNewPosition()
    {
        Transform newPosition = transform;
        while (newPosition == transform)
        {
            newPosition = positions[Random.Range(0, positions.Count())];
        }

        transform.position = newPosition.position;
        transform.rotation = newPosition.rotation;
    }

    public void CheckScarePoint()
    {
        Vector3 scarePoint = playerCamera.position + (playerCamera.forward * scarePointDistance);

        //Debug.DrawLine(playerCamera.transform.position, scarePoint);

        if (Vector3.Distance(transform.position, scarePoint) < scarePointThreshold)
        {
            EnterCooldown();
        }
    }
}
