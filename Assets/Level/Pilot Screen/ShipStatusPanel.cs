using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipStatusPanel : MonoBehaviour
{
    public TMProTypewriter typewriter;
    public PilotScreen pilotScreen;
    public GameObject shipStatsObject;

    public CockpitPanel warningScreen;
    public FadeToBlackScript fade;

    public bool shownDiagnosis;

    public bool allowKeyboard;

    public bool engineFixed;

    [Header("Texts:")]
    public TextMeshPro runDiagnosisText;
    public TextMeshPro problemsListText;

    public void Selected()
    {
        pilotScreen.EnableKeyboard(allowKeyboard);
        if (engineFixed)
        {
            StartCoroutine(EngineFixedText());
        }
    }

    private void Start()
    {
        allowKeyboard = true;
    }

    public void KeyboardPressed()
    {
        if (engineFixed)
        {
            StartCoroutine(AutopilotWorking());
        }
        else
        {
            shownDiagnosis = true;

            allowKeyboard = false;
            pilotScreen.EnableKeyboard(false);

            StartCoroutine(RunDiagnosis());
        }
    }


    public IEnumerator RunDiagnosis()
    {
        //yield return new WaitForSeconds(0.75f);
        yield return new WaitForSeconds(typewriter.Type("..#F./xx0x.2?  a//;lv 77yxl/ba2 ,,/s55a", runDiagnosisText, 0.02f));
        yield return new WaitForSeconds(0.5f);
        runDiagnosisText.text = "";
        yield return new WaitForSeconds(1.2f);
        yield return new WaitForSeconds(typewriter.Type("Multiple failures found\n\n<size=38>Restarting display </size>", "...", runDiagnosisText, 1f));
        runDiagnosisText.text = "";
        yield return new WaitForSeconds(0.5f);
        runDiagnosisText.text = "<size=32>##.asd Xx09s00)), kkjs2..,/ ??a-?6s ggsd,chhss,   ;;;as][\\xx000xa]       jjhls223ax</size>";
        yield return new WaitForSeconds(0.17f);
        runDiagnosisText.text = "";
        yield return new WaitForSeconds(0.5f);
        runDiagnosisText.text = "<size=28> starting heap in init/bl34/main.lls </size>";
        yield return new WaitForSeconds(0.28f);
        runDiagnosisText.text = "";
        yield return new WaitForSeconds(0.2f);

        shipStatsObject.SetActive(true);

        yield return new WaitForSeconds(typewriter.Type("<size=40>Problems Identified:\n</size>", 
        "\n- Main Fuse Array overdue maintainence (2 yrs 37 days) <color=#dd8323>[Severe]</color>" +
        "\n- Fuel seepage detected in left engineering bay <color=#dd8323>[Severe]</color>" +
        "\n- Stasis chambers (3, 4, 5, 6, 8) total shutdown <color=#990c00>[Extreme]</color>" +
        "\n- Communication Array overdue maintainence (92 days) <color=#d1af19>[Mild]</color>" +
        "\n- Left Engine coolant pipe broken <color=#990c00>[Extreme]</color>", problemsListText, 0.03f));

        yield return new WaitForSeconds(2f);
        problemsListText.text = "";

        yield return new WaitForSeconds(typewriter.Type("<size=40>Collision Imminent\n<color=#990c00>Autopilot unable to resolve escape vector</color></size>", runDiagnosisText, 0.03f));
    
        yield return new WaitForSeconds(2f);

        yield return new WaitForSeconds(typewriter.Type("<size=40>Collision Imminent\n<color=#990c00>Autopilot unable to resolve escape vector</color></size>", "<size=40>\n\nUrgent Maintainence of Left Engine required</size>", runDiagnosisText, 0.03f));
    
        pilotScreen.DiagnosisFinished();
    }

    public IEnumerator EngineFixedText()
    {
        shipStatsObject.SetActive(false);

        allowKeyboard = false;
        pilotScreen.EnableKeyboard(false);
        pilotScreen.EnableScreenSwitch(false);

        yield return new WaitForSeconds(typewriter.Type("..#F./xx0x.2?  a//;lv 77yxl/ba2 ,,/s55a", runDiagnosisText, 0.02f));
        yield return new WaitForSeconds(0.5f);
        runDiagnosisText.text = "";
        yield return new WaitForSeconds(1.2f);
        yield return new WaitForSeconds(typewriter.Type("<size=40>Left Engine: <color=#31d428>Operational</color>\n\nEscape Vector: <color=#d4d128>Found</color>\n\nInitiate Autopilot? (Y/N)</size>", runDiagnosisText, 0.02f));

        allowKeyboard = true;
        pilotScreen.EnableKeyboard(true);
    }

    public IEnumerator AutopilotWorking()
    {
        shipStatsObject.SetActive(false);

        allowKeyboard = false;
        pilotScreen.EnableKeyboard(false);

        warningScreen.Halt(); // Let the warning screen know that the ship is leaving and the player has won, prevents it from playing the losing code

        yield return new WaitForSeconds(typewriter.Type("Autopilot underway...", runDiagnosisText, 0.02f));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(fade.PlayerWin());
    }

}
