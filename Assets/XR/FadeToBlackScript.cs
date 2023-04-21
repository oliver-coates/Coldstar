using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlackScript : MonoBehaviour
{
    public Image img;

    public bool isFading;
    public float fadeAmount;
    public float fadeSpeed;

    public bool fadeInAtStartOfScene;

    public void Start()
    {
        if (fadeInAtStartOfScene)
        {
            img.color = new Color(0, 0, 0, 1f);
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeToBlack()
    {
        if (isFading) { yield break; }
        isFading = true;

        while (fadeAmount < 1)
        {
            fadeAmount += (Time.deltaTime * fadeSpeed);
            img.color = new Color(0, 0, 0, fadeAmount);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        isFading = false;
    }

    public IEnumerator FadeOut()
    {
        if (isFading) { yield break; }
        isFading = true;
        fadeAmount = 1f;

        while (fadeAmount > 0)
        {
            fadeAmount -= (Time.deltaTime * fadeSpeed);
            img.color = new Color(0, 0, 0, fadeAmount);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        isFading = false;
    }

}
