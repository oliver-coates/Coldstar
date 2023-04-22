using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeToBlackScript : MonoBehaviour
{
    public Image img;

    public bool isFading;
    public float fadeAmount;
    public float fadeSpeed;

    public bool fadeInAtStartOfScene;

    public TextMeshProUGUI winText1;
    public TextMeshProUGUI winText2;
    public TextMeshProUGUI loseText1;
    public TextMeshProUGUI loseText2;

    public AudioSource aud;
    public AudioClip deathSound;
    public AudioClip winSound;

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

    public IEnumerator FadeTextIn(TextMeshProUGUI text)
    {
        float amount = 0;
        while(amount < 1f)
        {
            amount += Time.deltaTime;
            text.color = new Color(1f, 1f, 1f, amount);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator PlayerWin()
    {
        aud.PlayOneShot(winSound);
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextIn(winText1));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeTextIn(winText2));
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Main Menu");
    }

    public IEnumerator PlayerLose()
    {
        aud.PlayOneShot(deathSound);
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextIn(loseText1));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeTextIn(loseText2));
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Main Menu");
    }

}
