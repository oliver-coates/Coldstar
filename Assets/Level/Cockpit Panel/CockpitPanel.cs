using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class CockpitPanel : MonoBehaviour
{
    public TextMeshPro textMesh;

    public TextCycle textCycle;

    private float timeElapsed;
    public float hullIntegrity;
    private string hullIntegrityString;
    public float timeToCollision = 900;
    private string timeToCollisionString;

    void Start()
    {
        LoadTextManually();

        StartCoroutine(cycleText());
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    public void CalculateValueStrings()
    {
        hullIntegrity = 0.0008222f * (timeToCollision - timeElapsed) + 0.13f; // Hull integrity function
        hullIntegrityString = Mathf.Round(hullIntegrity * 100f) + "%";

        TimeSpan t = TimeSpan.FromSeconds((timeToCollision - timeElapsed));
        timeToCollisionString = t.ToString(@"mm\:ss");
    }

    IEnumerator cycleText()
    {

        Tuple<string, float> output = textCycle.GetNextCycle();

        if (output == null)
        {
            // Finished pulling text from text schedule, generate a new one
            LoadTextManually();

            StartCoroutine(cycleText());
            yield break;
        }

        string text = output.Item1;
        float waitTime = output.Item2;

        textMesh.text = text;

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(cycleText());
    }

      
    void LoadTextManually()
    {
        CalculateValueStrings();
        textCycle = new TextCycle(2);

        textCycle.SetTextSegment(0, "<size=100><color=#fa0202>WARNING!</color></size>\n" +
                                    "<size=50>HULL INTEGRITY DROPPING</size>\n\n" +
                                    "<size=65>TIME UNTIL BREAKUP:</size>\n" +
                                    "<size=80><color=#e0962f>" + timeToCollisionString + "</color></size>", 2f);

        textCycle.SetTextSegment(1, "<size=100><color=#fa0202>WARNING!</color></size>\n" +
                                    "<size=50>HULL INTEGRITY DROPPING</size>\n\n" +
                                    "<size=65>HULL INTEGRITY:</size>\n" +
                                    "<size=80><color=#e0c62f>" + hullIntegrityString + "</color></size>", 2f);
    }
}


[Serializable]
public class TextCycle
{
    // Text segment keeps track of individual strings and waittimes
    [Serializable]
    public struct TextSegment
    {
        [TextArea]
        internal string text;

        internal float waitTime;
    }


    public TextSegment[] texts;
    private int cycleIteration;

    public TextCycle(int length)
    {
        cycleIteration = 0;
        texts = new TextSegment[length];
    }

    public Tuple<string, float> GetNextCycle()
    {
        if (this.texts.Count() == 0)
        {
            return new Tuple<string, float>("No texts attached", 10f);
        }

        if (cycleIteration > this.texts.Count() -1)
        {
            return null; // Null return indicates finished playing text
        }

        Tuple<string, float> result = new Tuple<string, float>(this.texts[cycleIteration].text, this.texts[cycleIteration].waitTime);

        cycleIteration++;

        return result;
    }

    public void SetTextSegment(int segmentNum, string newText, float newWaitTime)
    {
        texts[segmentNum].text = newText;
        texts[segmentNum].waitTime = newWaitTime;
    }
}
