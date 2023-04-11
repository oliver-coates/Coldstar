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

    public bool allowKeyboard;

    public bool killSwitchSelected = false;
    public bool safetyChipDisabled = false;
    


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
        }
        else
        {
            // Kill Engineer
            StartCoroutine(DeliverVoltage());
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
        statusText.text = "Status: Deceased \n" +
            "Location: Left Engineering Bay \n" +
            "Neural Link: <color=#80eb34>Available</color>" +
            "Warnings: \n" +
            "- <color=#eb291a>Nervous System Necrosis</color>";
    }
}
