using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScreen : MonoBehaviour
{
    public List<GameObject> screenPanels; // List of screenpanel gameobjects, can be added to dynamicaly in runtime
    private int screenPanelNum;

    public GameObject communicationsObj; // Communications Panel
    public GameObject enginerObj; // Engineer Panel

    public GameObject keyboardCenter;
    public GameObject keyboardButtonL;
    public GameObject keyboardButtonR;

    [Header("Panels:")]
    public ShipStatusPanel shipStatusPanel;
    public CommunicationsPanel communicationsPanel; 
    public EngineerPanel engineerPanel;

    [Header("Audio:")]
    private AudioSource localAudioSource;
    public AudioSource keyboardAudioSource;
    public AudioClip keyboardType;
    public AudioClip computerBeep;

    public void KeyboardPressed()
    {
        keyboardAudioSource.PlayOneShot(keyboardType);

        
        switch (screenPanelNum)
        {
            case (0): // On Ship status panel
                shipStatusPanel.KeyboardPressed();
                break;

            case (1): // Communications Panel
                communicationsPanel.KeyboardPressed();
                break;

            case (2): // Engineer status panel
                engineerPanel.KeyboardPressed();
                break;
        }
    }

    public void EnableKeyboard(bool enabled)
    {
        keyboardCenter.SetActive(enabled);
    }

    public void EnableScreenSwitch(bool enabled)
    {
        keyboardButtonL.SetActive(enabled);
        keyboardButtonR.SetActive(enabled);
    }

    public void NextPanel(bool reverse=false)
    {
        localAudioSource.PlayOneShot(computerBeep);

        screenPanels[screenPanelNum].SetActive(false);

        // Add or remove one from screenPanelNum
        if (reverse) {screenPanelNum -= 1; }
        else {screenPanelNum += 1; }

        if (screenPanelNum > screenPanels.Count-1)
        {
            // If advanced too far, loop back around
            screenPanelNum = 0;
        }
        else if (screenPanelNum < 0)
        {
            // If backed too far, loop to front.
            screenPanelNum = screenPanels.Count-1;
        }

        screenPanels[screenPanelNum].SetActive(true);
        screenPanels[screenPanelNum].SendMessage("Selected", SendMessageOptions.DontRequireReceiver);
    }

    public void DiagnosisFinished()
    {
        screenPanels.Add(communicationsObj);

        // Enable keyboard Left and Right arrows!
        keyboardButtonL.SetActive(true);
        keyboardButtonR.SetActive(true);
    }

    public void EngineerDialogueFinished()
    {
        screenPanels.Add(enginerObj);
    }

    public void ChipRemoved()
    {
        engineerPanel.safetyChipDisabled = true;
    }




    private void Start() {
        localAudioSource = gameObject.GetComponent<AudioSource>();
    }    


    public void EngineFixed()
    {
        shipStatusPanel.engineFixed = true;
        StartCoroutine(returnPlayer());

        engineerPanel.neuralLinkMessage.SetActive(false);
        engineerPanel.allowKeyboard = false;
        engineerPanel.engineFixed = true;

        EnableKeyboard(false);
        EnableScreenSwitch(true);
    }

    private IEnumerator returnPlayer()
    {
        engineerPanel.fade.StartCoroutine(engineerPanel.fade.FadeToBlack());
        yield return new WaitForSeconds(5f);
        engineerPanel.XRorigin.transform.position = engineerPanel.cockpitAnchor.position;
        engineerPanel.fade.StartCoroutine(engineerPanel.fade.FadeOut());
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EngineFixed();
        }
    }*/

    

}
