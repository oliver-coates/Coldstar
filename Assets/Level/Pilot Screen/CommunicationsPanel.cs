using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommunicationsPanel : MonoBehaviour
{
    public PilotScreen pilotScreen;
    public TMProTypewriter typewriter;
    public TextMeshPro textMesh;

    public void Selected()
    {

    }

    public IEnumerator Startup()
    {
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(typewriter.Type("", "..#F./xx0x.2?  a//;lv 77yxl/ba2 ,,/s55a", 0.02f));
    }

    public void KeyboardPressed()
    {

    }
}
