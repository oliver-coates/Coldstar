using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EngineerPanel : MonoBehaviour
{

    public PilotScreen pilotScreen;

    public TextMeshPro statusText;
    public TextMeshPro inputText;
    public GameObject warningMessage;
    public GameObject neuralLinkMessage;
    public TextMeshPro neuralLinkText;

    public bool allowKeyboard;

    public bool killSwitchSelected = false;
    public bool safetyChipDisabled = false;
    public bool engineerKilled = false;

    public FadeToBlackScript fade;

    public ButtonScript button;

    public void Selected()
    {
        pilotScreen.EnableKeyboard(allowKeyboard);
    }

    public void KeyboardPressed()
    {
        if (killSwitchSelected == false)
        {
            // Update to kill switch
            SelectKillSwitch();
        }
        else if (safetyChipDisabled == false)
        {
            // Flash warning message
            StartCoroutine(WarningMessage());
            
            // Allow the button to be used
            if (button.isAllowed() == false)
            {
                button.AllowButton();
            }
        }
        else if (engineerKilled == false)
        {
            // Kill Engineer
            StartCoroutine(DeliverVoltage());
        }
        else
        {
            // Activate Neural Link
            StartCoroutine(ActivateNeuralLink());
        }
    }

    

    private void SelectKillSwitch()
    {
        killSwitchSelected = true;
        inputText.text = "Action Selected: Voltage Delivery - 320V @ 0.6A \n<size=18>Warning! Lethal load selected!</size> ";
    }

    private IEnumerator WarningMessage()
    {
        pilotScreen.EnableKeyboard(false);
        pilotScreen.EnableScreenSwitch(false);

        warningMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningMessage.SetActive(false);

        pilotScreen.EnableKeyboard(true);
        pilotScreen.EnableScreenSwitch(true);
    }

    private IEnumerator DeliverVoltage()
    {
        pilotScreen.EnableKeyboard(false);
        pilotScreen.EnableScreenSwitch(false);

        inputText.text = "Working...";

        // Play screaming sound

        yield return new WaitForSeconds(3f);

        KillEngineer();
        
    }

    private void KillEngineer()
    {

        inputText.text = "Success - Volage Delivered";
        statusText.text = "Status: Deceased \n\n" +
            "Location: Left Engineering Bay \n\n" +
            "Neural Link: <color=#80eb34>Available</color> \n\n" +
            "Warnings: \n" +
            "- <color=#eb291a>Nervous System Necrosis</color>";
        engineerKilled = true;

        pilotScreen.EnableKeyboard(true);
        pilotScreen.EnableScreenSwitch(true);
    }

    private IEnumerator ActivateNeuralLink()
    {
        pilotScreen.EnableKeyboard(false);
        pilotScreen.EnableScreenSwitch(false);

        inputText.text = "";
        statusText.text = "";

        neuralLinkMessage.SetActive(true);

        int percentageDone = 0;
        string[] phrases = { "RELAX", "LET GO", "BECOME ONE", "SLEEP" };

        while(percentageDone < 100)
        {
            percentageDone += Random.Range(3, 10);
            percentageDone = Mathf.Clamp(percentageDone, 0, 100);
            neuralLinkText.text = "[" + percentageDone + "%] <color=#f5da42>" + phrases[Random.Range(0, 4)] + "</color>";

            yield return new WaitForSeconds(0.7f);

        }

        // ACTIVATE NEURAL LINK !!!

        // play sound

        // fade
        StartCoroutine(fade.FadeToBlack());


    }
}
