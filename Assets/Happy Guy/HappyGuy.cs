using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyGuy : MonoBehaviour
{
    public enum state {fadingIn, fadingOut, cooldown}
    public state currentState;
    public Material myMaterial;

    public float fadeSpeed;
    public float fadeOutSpeed;
    public float alphaAmount;

    public float cooldownTime;
    private float cooldownTimer;

    void Start()
    {
       EnterCooldown();
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
}
