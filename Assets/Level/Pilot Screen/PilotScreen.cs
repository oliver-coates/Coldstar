using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScreen : MonoBehaviour
{
    public bool test1;

    public List<GameObject> screenPanels; // List of screenpanel gameobjects, can be added to dynamicaly in runtime
    private int screenPanelNum;

    public GameObject communicationsObj;

    [Header("Panels:")]
    public ShipStatusPanel shipStatusPanel;

    void NextPanel(bool reverse=false)
    {
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
