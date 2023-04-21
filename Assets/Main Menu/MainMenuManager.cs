using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private bool isCurrentlyWorking;
    

    public FadeToBlackScript fadeScript;

    private void Start()
    {
        isCurrentlyWorking = false;
    }

    public void PlayGame()
    {
        if (isCurrentlyWorking) { return; }
        StartCoroutine(startGame());
        isCurrentlyWorking = true;
    }

    private IEnumerator startGame()
    {
        StartCoroutine(fadeScript.FadeToBlack());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
