using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScreen : MonoBehaviour
{
    public bool test1;

    public List<GameObject> screenPanels; // List of screenpanel gameobjects, can be added to dynamicaly in runtime
    private int screenPanelNum;

    public GameObject communicationsObj; // Communications Panel

    public GameObject keyboardButtonL;
    public GameObject keyboardButtonR;

    [Header("Panels:")]
    public ShipStatusPanel shipStatusPanel;

    [Header("Audio:")]
    private AudioSource localAudioSource;
    public AudioSource keyboardAudioSource;
    public AudioClip keyboardType;
    public AudioClip computerBeep;

    public void KeyboardPressed()
    {
        keyboardAudioSource.PlayOneShot(keyboardType);
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
    }

    public void DiagnosisFinished()
    {
        screenPanels.Add(communicationsObj);

        // Enable keyboard Left and Right arrows!
        keyboardButtonL.SetActive(true);
        keyboardButtonR.SetActive(true);
    }

    



    private void Start() {
        localAudioSource = gameObject.GetComponent<AudioSource>();
    }    

    // Update is called once per frame
    void Update()
    {
        if(test1)
        {
            test1 = false;
            shipStatusPanel.StartDiagnosis();
        }
    }


    
}
