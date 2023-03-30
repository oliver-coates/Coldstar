using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMProTypewriter : MonoBehaviour
{
    public TextMeshPro defaultText;


    public float Type(string message, TextMeshPro text, float letterPrintTime)
    {
        return TypeM("", message, text, letterPrintTime);
    }

    public float Type(string startingMessage, string message, TextMeshPro text, float letterPrintTime)
    {
        return TypeM(startingMessage, message, text, letterPrintTime);
    }

    public float Type(string startingMessage, string message, float letterPrintTime)
    {
        return TypeM(startingMessage, message, defaultText, letterPrintTime);
    }

    public float Type(string message, float letterPrintTime)
    {
        return TypeM("", message, defaultText, letterPrintTime);
    }

    private float TypeM(string startingMessage, string message, TextMeshPro text, float letterPrintTime)
    {
        char[] characters = message.ToCharArray();
        StartCoroutine(typeWriter(startingMessage, characters, text, letterPrintTime));

        return (characters.Length * letterPrintTime); // Return time taken
    }

    private IEnumerator typeWriter(string startingMessage, char[] characters, TextMeshPro text, float letterPrintTime)
    {
        string fullMessage = startingMessage;
        bool isRichText = false;

        foreach (char c in characters)
        {
            if (c.ToString() == "<")
            {
                isRichText = true;
            }

            fullMessage += c;

            if (isRichText)
            {
                
                if (c.ToString() == ">")
                {
                    // rich text has finished
                    isRichText = false;
                    text.text = fullMessage;
                    yield return new WaitForSeconds(letterPrintTime);
                }
            }
            else
            {
                text.text = fullMessage;
                yield return new WaitForSeconds(letterPrintTime);
            }

        }
    }
}
